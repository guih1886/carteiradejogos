using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;
using Newtonsoft.Json;
using System.Net;

namespace CarteiraDeJogosTest.ControllersTest;

[Collection("JogosControllerTest")]
public class JogosControllerTest : IDisposable
{
    private HttpClientBuilder _httpClient = new HttpClientBuilder();
    private ReadJogosDto jogo;

    public JogosControllerTest()
    {
        CreateJogosDto jogo = new CreateJogosDto("Endereço de imagem da internet", "Jogo Teste", "Um jogo de teste para o testes do controlador", Genero.Estratégia, 1, "2000", "Atari", 8);
        Task<HttpResponseMessage> response = _httpClient.CadastrarAsync("/Jogos", jogo);
        Task<string> content = response.Result.Content.ReadAsStringAsync();
        this.jogo = JsonConvert.DeserializeObject<ReadJogosDto>(content.Result)!;
    }

    [Fact]
    public void CadastrarJogosTest()
    {
        //Arrange
        //Act
        //Assert
        Assert.Equal(1, jogo.Ativo);
        Assert.Equal("Jogo Teste", jogo.Nome);
    }

    [Fact]
    public async void AdicionarJogoNaListaDoUsuarioAoCadastrarJogoTest()
    {
        //Arrange
        HttpResponseMessage response = await _httpClient.BuscarAsync("/JogosDoUsuario/1/todosJogos");
        string listaDeJogos = await response.Content.ReadAsStringAsync();
        var a = listaDeJogos.ToList();
        //Act
        //bool jogoNaLista = usuario.Jogos.Contains(jogo.Id);
        //Assert
        //Assert.True(jogoNaLista);
    }

    [Fact]
    public async void CadastrarJogoComUsuarioIdIncorretoTest()
    {
        //Arrange
        CreateJogosDto jogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 0, "1994", "PS4", 9);
        //Act
        HttpResponseMessage response = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", jogo);
        string erro = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Contains("Erro ao localizar o usuário", erro);
    }

    [Fact]
    public async void AlterarJogosTest()
    {
        //Arrange
        UpdateJogosDto jogo = new UpdateJogosDto("Endereço Teste", "Jogo Alterado", "Descrição de Teste alterada para o modelo.", Genero.Ação, "1994", "PS4", 9);
        //Act
        HttpResponseMessage responseJogoAlterado = await _httpClient.AlterarAsync($"/Jogos/{this.jogo.Id}", jogo);
        ReadJogosDto jogoAlterado = JsonConvert.DeserializeObject<ReadJogosDto>(await responseJogoAlterado.Content.ReadAsStringAsync())!;
        //Assert
        Assert.Equal("Jogo Alterado", jogoAlterado.Nome);
    }

    [Fact]
    public async void ListarJogosTest()
    {
        //Arrange
        //Act
        HttpResponseMessage resultado = await _httpClient.BuscarAsync("/Jogos");
        //Assert        
        Assert.True(resultado.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async void ListarJogosPorIdTest()
    {
        //Arrange
        //Act
        HttpResponseMessage resultado = await _httpClient.BuscarAsync($"/Jogos/{jogo.Id}");
        ReadJogosDto jogoBuscado = JsonConvert.DeserializeObject<ReadJogosDto>(await resultado.Content.ReadAsStringAsync())!;
        //Assert
        Assert.Equal(jogoBuscado.Id, jogo.Id);
    }

    [Fact]
    public async void ListarJogosPorIdIncorretoTest()
    {
        //Arrange
        //Act
        HttpResponseMessage resultado = await _httpClient.BuscarAsync($"/Jogos/0");
        //Assert
        Assert.Equal(HttpStatusCode.NotFound, resultado.StatusCode);
    }

    [Fact]
    public async void DeletarJogosTest()
    {
        //Arrange
        //Act
        HttpResponseMessage deleteResponse = await _httpClient.DeletarAsync($"/Jogos/{jogo.Id}");
        //Assert
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
    }

    [Fact]
    public async void DeletarJogoDaListaDoUsuarioTest()
    {
        //Arrange
        //Act
        await _httpClient.IncluirJogoNosFavoritos(1, jogo.Id);
        await _httpClient.DeletarAsync($"/Jogos/{jogo.Id}");
        HttpResponseMessage response = await _httpClient.BuscarAsync("/Usuarios/1");
        string content = await response.Content.ReadAsStringAsync();
        ReadUsuariosDto usuarioDto = JsonConvert.DeserializeObject<ReadUsuariosDto>(content)!;
        bool estaNaLista = usuarioDto.Jogos.Contains(jogo.Id);
        bool estaNaListaFavoritos = usuarioDto.Jogos.Contains(jogo.Id);
        //Assert
        Assert.False(estaNaLista);
        Assert.False(estaNaListaFavoritos);
    }

    [Fact]
    public async void DeletarJogosIncorretoTest()
    {
        //Arrange
        //Act
        HttpResponseMessage deleteResponse = await _httpClient.DeletarAsync($"/Jogos/0");
        //Assert
        Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);
    }

    public async void Dispose()
    {
        await _httpClient.DeletarAsync($"/Jogos/{jogo.Id}");
        await _httpClient.DeletarAsync($"/JogosDoUsuario/{1}/removerJogo/{jogo.Id}");
    }
}
