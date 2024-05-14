using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;
using System.Net;
using System.Text.Json;
using Xunit.Abstractions;

namespace CarteiraDeJogosTest.ControllersTest;

[Collection("JogosDoUsuarioControllerTest")]
public class JogosDoUsuarioControllerTest : IDisposable
{
    private HttpClientBuilder _httpClientBuilder;
    private ITestOutputHelper _outputHelper;
    private ReadJogosDto jogo;

    public JogosDoUsuarioControllerTest(ITestOutputHelper outputHelper)
    {
        _httpClientBuilder = new HttpClientBuilder();
        _outputHelper = outputHelper;
        CreateJogosDto jogo = new CreateJogosDto("Endereço de imagem da internet", "Jogo teste do JogosDoUsuarioTeste", "Um jogo de teste para o testes do controlador", Genero.Estratégia, 1, "2000", "Atari", 8);
        Task<HttpResponseMessage> response = _httpClientBuilder.CadastrarAsync("/Jogos", jogo);
        this.jogo = JsonSerializer.Deserialize<ReadJogosDto>(response.Result.Content.ReadAsStringAsync().Result)!;
    }
    [Fact]
    public async void AdicionaJogoAtivoAosJogosFavoritos()
    {
        //Arrange
        //Act
        //Cadastrando os jogos
        //Serealizando os resultado no usuário
        HttpResponseMessage responseUsuario = await _httpClientBuilder.BuscarAsync($"/Usuarios/1");
        ReadUsuariosDto usuarioDto = JsonSerializer.Deserialize<ReadUsuariosDto>(responseUsuario.Content.ReadAsStringAsync().Result)!;
        //Incluindo o jogo na lista de favoritos
        HttpResponseMessage respondeInclusao1 = await _httpClientBuilder.IncluirJogoNosFavoritos(usuarioDto.Id, jogo.Id);
        //Buscando o usuário final com o jogo incluso e serializando para os asserts
        HttpResponseMessage usuarioDtoIncluso = await _httpClientBuilder.BuscarAsync($"/Usuarios/{usuarioDto.Id}");
        ReadUsuariosDto usuarioFinal = JsonSerializer.Deserialize<ReadUsuariosDto>(usuarioDtoIncluso.Content.ReadAsStringAsync().Result)!;
        //Assert
        Assert.Equal(HttpStatusCode.OK, respondeInclusao1.StatusCode);
        Assert.Contains(jogo.Id, usuarioFinal.JogosFavoritos);
    }
    [Fact]
    public async void NaoAdicionaJogoQueNaoEstaNaListaAosJogosFavoritos()
    {
        //Arrange
        //Act
        HttpResponseMessage responseInclusao1 = await _httpClientBuilder.IncluirJogoNosFavoritos(1, 9999);
        string erro = responseInclusao1.Content.ReadAsStringAsync().Result;
        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, responseInclusao1.StatusCode);
        Assert.Contains("Jogo não está na lista de jogos.", erro);
    }

    [Fact]
    public async void NaoAdicionaJogoQueJaEstaNaListaDeJogosFavoritos()
    {
        //Arrange
        //Act
        await _httpClientBuilder.IncluirJogoNosFavoritos(1, jogo.Id);
        HttpResponseMessage responseInclusao500 = await _httpClientBuilder.IncluirJogoNosFavoritos(1, jogo.Id);
        string erro = responseInclusao500.Content.ReadAsStringAsync().Result;
        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, responseInclusao500.StatusCode);
        Assert.Contains("Jogo já está na lista.", erro);
    }

    [Fact]
    public async void NaoAdicionaJogoAosJogosFavoritosDeUsuarioNaoEncontrado()
    {
        HttpResponseMessage responseInclusao500 = await _httpClientBuilder.IncluirJogoNosFavoritos(99, 1);
        string erro = responseInclusao500.Content.ReadAsStringAsync().Result;
        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, responseInclusao500.StatusCode);
        Assert.Contains("Usuário não encontrado.", erro);
    }

    [Fact]
    public async void ListaJogosDoUsuario()
    {
        //Arrange
        //Act
        HttpResponseMessage response = await _httpClientBuilder.BuscarAsync("/JogosDoUsuario/1/todosJogos");
        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void NaoListaJogosDoUsuarioInvalido()
    {
        //Arrange
        //Act
        HttpResponseMessage response = await _httpClientBuilder.BuscarAsync("/JogosDoUsuario/999/todosJogos");
        string erro = response.Content.ReadAsStringAsync().Result;
        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        Assert.Contains("Usuário não encontrado.", erro);
    }

    [Fact]
    public async void ListaJogosFavoritosDoUsuario()
    {
        //Arrange
        //Act
        HttpResponseMessage response = await _httpClientBuilder.BuscarAsync("/JogosDoUsuario/1/jogosfavoritos");
        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async void NaoListaJogosFavoritosDoUsuarioInvalido()
    {
        //Arrange
        //Act
        HttpResponseMessage response = await _httpClientBuilder.BuscarAsync("/JogosDoUsuario/999/jogosfavoritos");
        string erro = response.Content.ReadAsStringAsync().Result;
        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        Assert.Contains("Usuário não encontrado.", erro);
    }

    [Fact]
    public async void RemoveOJogoDaListaEMarcaComoInativo()
    {
        //Arrange
        //Act
        HttpResponseMessage response = await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/{1}/removerJogo/{jogo.Id}");
        HttpResponseMessage responseUsuario = await _httpClientBuilder.BuscarAsync($"/Usuarios/1");
        ReadUsuariosDto usuarioDto = JsonSerializer.Deserialize<ReadUsuariosDto>(responseUsuario.Content.ReadAsStringAsync().Result)!;
        HttpResponseMessage responsejogo = await _httpClientBuilder.BuscarAsync($"/Jogos/{jogo.Id}");
        //Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        Assert.Equal(HttpStatusCode.NotFound, responsejogo.StatusCode);
        Assert.True(!usuarioDto.Jogos.Contains(jogo.Id));
    }

    [Fact]
    public async void NaoRemoveOJogoDaListaComUsuarioIncorreto()
    {
        //Arrange
        //Act
        HttpResponseMessage response = await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/{0}/removerJogo/{1}");
        string error = response.Content.ReadAsStringAsync().Result;
        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        Assert.Contains("Usuário não encontrado.", error);
    }

    [Fact]
    public async void NaoRemoveOJogoDaListaComJogoIncorreto()
    {
        //Arrange
        //Act
        HttpResponseMessage response = await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/{1}/removerJogo/{0}");
        string error = response.Content.ReadAsStringAsync().Result;
        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        Assert.Contains("Jogo não está na lista.", error);
    }

    [Fact]
    public async void RemoveOJogoDaListaFavorito()
    {
        //Arrange
        //Act
        await _httpClientBuilder.IncluirJogoNosFavoritos(1, jogo.Id);
        HttpResponseMessage response = await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/{1}/removerJogoFavorito/{jogo.Id}");
        HttpResponseMessage responseUsuario = await _httpClientBuilder.BuscarAsync($"/Usuarios/1");
        ReadUsuariosDto usuarioDto = JsonSerializer.Deserialize<ReadUsuariosDto>(responseUsuario.Content.ReadAsStringAsync().Result)!;
        _outputHelper.WriteLine($"/JogosDoUsuario/{1}/removerJogoFavorito/{jogo.Id}");
        _outputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
        //Assert
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        Assert.True(!usuarioDto.JogosFavoritos.Contains(jogo.Id));
    }

    [Fact]
    public async void NaoRemoveOJogoFavoritoDaListaComUsuarioIncorreto()
    {
        //Arrange
        //Act
        HttpResponseMessage response = await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/{0}/removerJogoFavorito/{1}");
        string error = response.Content.ReadAsStringAsync().Result;
        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        Assert.Contains("Usuário não encontrado.", error);
    }

    [Fact]
    public async void NaoRemoveOJogoFavoritoDaListaComJogoIncorreto()
    {
        //Arrange
        //Act
        HttpResponseMessage response = await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/{1}/removerJogoFavorito/{0}");
        string error = response.Content.ReadAsStringAsync().Result;
        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        Assert.Contains("Jogo não está na lista.", error);
    }

    public async void Dispose()
    {
        await _httpClientBuilder.DeletarAsync($"/Jogos/{jogo.Id}");
        await _httpClientBuilder.DeletarAsync($"/JogosDoUsuario/{1}/removerJogo/{jogo.Id}");
        _outputHelper.WriteLine($"Jogo {jogo.Id} deletado com sucesso.");
    }
}
