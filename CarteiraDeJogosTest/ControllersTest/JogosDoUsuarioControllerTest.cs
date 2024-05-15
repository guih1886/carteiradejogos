using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Models;
using Newtonsoft.Json;
using System.Net;
using Xunit.Abstractions;

namespace CarteiraDeJogosTest.ControllersTest;

[Collection("JogosDoUsuarioControllerTest")]
public class JogosDoUsuarioControllerTest
{
    private HttpClientBuilder _httpClientBuilder = new HttpClientBuilder();
    private ITestOutputHelper _outputHelper;
    private ReadJogosDto jogo;

    public JogosDoUsuarioControllerTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        CreateJogosDto jogo = new CreateJogosDto("Endereço de imagem da internet", "Jogo teste do JogosDoUsuarioTeste", "Um jogo de teste para o testes do controlador", Genero.Estratégia, 1, "2000", "Atari", 8);
        Task<HttpResponseMessage> response = _httpClientBuilder.CadastrarAsync("/Jogos", jogo);
        this.jogo = JsonConvert.DeserializeObject<ReadJogosDto>(response.Result.Content.ReadAsStringAsync().Result)!;
        _outputHelper.WriteLine($"Criando jogo {this.jogo.Id}");
    }

    [Fact]
    public async void AdicionaJogoFavoritoAoUsuarioTest()
    {
        //Arrange
        //Act
        int idDoJogo = jogo.Id;
        HttpResponseMessage response = await _httpClientBuilder.IncluirJogoNosFavoritos(1, idDoJogo);
        List<int> lista = JsonConvert.DeserializeObject<List<int>>(await response.Content.ReadAsStringAsync())!;
        ApagarJogoCriado();
        ApagarJogoListaDeFavorito(idDoJogo);
        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains(idDoJogo, lista);
    }
    [Fact]
    public async void NaoAdicionaJogoFavoritoQueJaEstaNaListaTest()
    {
        //Arrange
        //Act
        int idJogo = jogo.Id;
        await _httpClientBuilder.IncluirJogoNosFavoritos(1, idJogo);
        HttpResponseMessage response = await _httpClientBuilder.IncluirJogoNosFavoritos(1, idJogo);
        ApagarJogoCriado();
        ApagarJogoListaDeFavorito(idJogo);
        string erro = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Contains("Jogo já está na lista.", erro);
    }
    [Fact]
    public async void NaoAdicionaJogoFavoritoQueNaoEstaNaListaDeJogosTest()
    {
        //Arrange
        ApagarJogoCriado();
        //Act
        HttpResponseMessage response = await _httpClientBuilder.IncluirJogoNosFavoritos(1, 99);
        string erro = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Contains("Jogo não está na lista de jogos.", erro);
    }
    [Fact]
    public async void UsuarioIncorretoTest()
    {
        //Arrange
        //Act
        int idJogo = jogo.Id;
        ApagarJogoCriado();
        HttpResponseMessage response = await _httpClientBuilder.IncluirJogoNosFavoritos(0, idJogo);
        string erro = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Contains("Usuário não encontrado.", erro);
    }
    [Fact]
    public async void ListaOsJogosTest()
    {
        //Arrange
        //Act
        ApagarJogoCriado();
        HttpResponseMessage response = await _httpClientBuilder.BuscarAsync("/JogosDoUsuario/1/todosJogos");
        string lista = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.StartsWith("[", lista);
        Assert.EndsWith("]", lista);
    }
    [Fact]
    public async void NaoListaOsJogosUsuarioIncorretoTest()
    {
        //Arrange
        //Act
        ApagarJogoCriado();
        HttpResponseMessage response = await _httpClientBuilder.BuscarAsync("/JogosDoUsuario/0/todosJogos");
        string erro = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Contains("Usuário não encontrado.", erro);
    }
    [Fact]
    public async void ListaOsJogosFavoritosTest()
    {
        //Arrange
        //Act
        ApagarJogoCriado();
        HttpResponseMessage response = await _httpClientBuilder.BuscarAsync("/JogosDoUsuario/1/jogosfavoritos");
        string lista = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.StartsWith("[", lista);
        Assert.EndsWith("]", lista);
    }
    [Fact]
    public async void NaoListaOsJogosFavoritosUsuarioIncorretoTest()
    {
        //Arrange
        //Act
        ApagarJogoCriado();
        HttpResponseMessage response = await _httpClientBuilder.BuscarAsync("/JogosDoUsuario/0/jogosfavoritos");
        string erro = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Contains("Usuário não encontrado.", erro);
    }
    [Fact]
    public async void RemoveJogoDoUsuarioTest()
    {
        //Arrange
        //Act
        HttpResponseMessage response = await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/1/removerJogo/{jogo.Id}");
        ApagarJogoCriado();
        //Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
    [Fact]
    public async void NaoRemoveJogoDoUsuarioIncorretoTest()
    {
        //Arrange
        //Act
        int idJogo = jogo.Id;
        ApagarJogoCriado();
        HttpResponseMessage response = await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/0/removerJogo/{idJogo}");
        string mensagem = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Contains("Usuário não encontrado.", mensagem);
    }
    [Fact]
    public async void NaoRemoveJogoDoUsuarioQueNaoEstaNaListaTest()
    {
        //Arrange
        //Act
        int idJogo = jogo.Id;
        ApagarJogoCriado();
        HttpResponseMessage response = await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/1/removerJogo/99");
        string mensagem = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Contains("Jogo não está na lista.", mensagem);
    }
    [Fact]
    public async void RemoveJogoFavoritoDoUsuarioTest()
    {
        //Arrange
        //Act
        int idJogo = jogo.Id;
        ApagarJogoCriado();
        await _httpClientBuilder.IncluirJogoNosFavoritos(1, idJogo);
        HttpResponseMessage response = await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/1/removerJogoFavorito/{idJogo}");
        ApagarJogoListaDeFavorito(idJogo);
        //Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
    [Fact]
    public async void NaoRemoveJogoFavoritoDoUsuarioIncorretoTest()
    {
        //Arrange
        //Act
        ApagarJogoCriado();
        HttpResponseMessage response = await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/0/removerJogoFavorito/1");
        string mensagem = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        Assert.Contains("Usuário não encontrado.", mensagem);
    }
    [Fact]
    public async void NaoRemoveJogoFavoritoDoUsuarioQueNaoEstaNaListaTest()
    {
        //Arrange
        //Act
        ApagarJogoCriado();
        HttpResponseMessage response = await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/1/removerJogoFavorito/9");
        string mensagem = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Contains("Jogo não está na lista.", mensagem);
    }

    private async void ApagarJogoCriado()
    {
        _outputHelper.WriteLine($"Apagando jogo {jogo.Id}");
        await _httpClientBuilder.DeletarAsync($"/Jogos/{jogo.Id}");
    }
    private async void ApagarJogoListaDeFavorito(int idJogoFavorito)
    {
        _outputHelper.WriteLine($"Apagando jogo favorito {idJogoFavorito}");
        await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/1/removerJogoFavorito/{idJogoFavorito}");
    }
}
