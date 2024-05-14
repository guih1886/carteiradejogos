using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;
using System.Net;
using System.Text.Json;
using Xunit.Abstractions;

namespace CarteiraDeJogosTest.ControllersTest;

public class JogosDoUsuarioControllerTest
{
    private HttpClientBuilder _httpClientBuilder;
    private ITestOutputHelper _outputHelper;

    public JogosDoUsuarioControllerTest(ITestOutputHelper outputHelper)
    {
        _httpClientBuilder = new HttpClientBuilder();
        _outputHelper = outputHelper;
    }

    [Fact]
    public async void AdicionaJogoAtivoAosJogosFavoritos()
    {
        //Arrange
        CreateJogosDto jogo1 = new CreateJogosDto("Endereço de imagem da internet", "Jogo teste do JogosDoUsuarioTeste", "Um jogo de teste para o testes do controlador", Genero.Estratégia, 1, "2000", "Atari", 8);
        CreateJogosDto jogo2 = new CreateJogosDto("Endereço de imagem da internet", "Jogo teste do JogosDoUsuarioTeste 2", "Um jogo de teste para o testes do controlador", Genero.Estratégia, 1, "2000", "Atari", 8);
        //Act
        //Cadastrando os jogos
        await _httpClientBuilder.CadastrarAsync("/Jogos", jogo1);
        await _httpClientBuilder.CadastrarAsync("/Jogos", jogo2);
        //Serealizando os resultado no usuário
        HttpResponseMessage responseUsuario = await _httpClientBuilder.BuscarAsync($"/Usuarios/1");
        ReadUsuariosDto usuarioDto = JsonSerializer.Deserialize<ReadUsuariosDto>(responseUsuario.Content.ReadAsStringAsync().Result)!;
        //Incluindo os jogos na lista de favoritos, buscando o usuário final com os jogos inclusos e serializando para os asserts
        int primeiroJogo = usuarioDto.Jogos[0];
        int segundoJogo = usuarioDto.Jogos[1];
        HttpResponseMessage respondeInclusao1 = await _httpClientBuilder.IncluirJogoNosFavoritos(usuarioDto.Id, primeiroJogo);
        HttpResponseMessage respondeInclusao2 = await _httpClientBuilder.IncluirJogoNosFavoritos(usuarioDto.Id, segundoJogo);
        HttpResponseMessage usuarioDtoIncluso = await _httpClientBuilder.BuscarAsync($"/Usuarios/{usuarioDto.Id}");
        ReadUsuariosDto usuarioFinal = JsonSerializer.Deserialize<ReadUsuariosDto>(usuarioDtoIncluso.Content.ReadAsStringAsync().Result)!;
        _outputHelper.WriteLine(usuarioFinal.ToString());
        //Assert
        Assert.Equal(HttpStatusCode.OK, respondeInclusao1.StatusCode);
        Assert.Equal(HttpStatusCode.OK, respondeInclusao2.StatusCode);
        Assert.Contains(primeiroJogo, usuarioFinal.JogosFavoritos);
        Assert.Contains(segundoJogo, usuarioFinal.JogosFavoritos);
        await _httpClientBuilder.DeletarAsync($"/Jogos/{primeiroJogo}");
        await _httpClientBuilder.DeletarAsync($"/Jogos/{segundoJogo}");
    }

    [Fact]
    public async void NaoAdicionaJogoQueNaoEstaNaListaAosJogosFavoritos()
    {
        //Arrange
        CreateJogosDto jogo = new CreateJogosDto("Endereço de imagem da internet", "Jogo teste do JogosDoUsuarioTeste", "Um jogo de teste para o testes do controlador", Genero.Estratégia, 1, "2000", "Atari", 8);
        //Act
        HttpResponseMessage response = await _httpClientBuilder.CadastrarAsync("/Jogos", jogo);
        ReadJogosDto jogoCriado = JsonSerializer.Deserialize<ReadJogosDto>(response.Content.ReadAsStringAsync().Result)!;
        await _httpClientBuilder.DeletarAsync($"/Jogos/{jogoCriado.Id}");

        //Serealizando os resultado no usuário
        HttpResponseMessage responseUsuario = await _httpClientBuilder.BuscarAsync($"/Usuarios/1");
        ReadUsuariosDto usuarioDto = JsonSerializer.Deserialize<ReadUsuariosDto>(responseUsuario.Content.ReadAsStringAsync().Result)!;
        HttpResponseMessage responseInclusao1 = await _httpClientBuilder.IncluirJogoNosFavoritos(usuarioDto.Id, jogoCriado.Id);
        string erro = responseInclusao1.Content.ReadAsStringAsync().Result;
        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, responseInclusao1.StatusCode);
        Assert.Contains("Jogo não está na lista de jogos.", erro);
    }

    [Fact]
    public async void NaoAdicionaJogoQueJaEstaNaListaDeJogosFavoritos()
    {
        //Arrange
        CreateJogosDto jogo = new CreateJogosDto("Endereço de imagem da internet", "Jogo teste do JogosDoUsuarioTeste", "Um jogo de teste para o testes do controlador", Genero.Estratégia, 1, "2000", "Atari", 8);
        //Act
        HttpResponseMessage response = await _httpClientBuilder.CadastrarAsync("/Jogos", jogo);
        ReadJogosDto jogoCriado = JsonSerializer.Deserialize<ReadJogosDto>(response.Content.ReadAsStringAsync().Result)!;
        await _httpClientBuilder.IncluirJogoNosFavoritos(1, jogoCriado.Id);
        HttpResponseMessage responseInclusao500 = await _httpClientBuilder.IncluirJogoNosFavoritos(1, jogoCriado.Id);
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
    public async void ListaJogosDoUsuarioInvalido()
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
    public async void ListaJogosFavoritosDoUsuarioInvalido()
    {
        //Arrange
        //Act
        HttpResponseMessage response = await _httpClientBuilder.BuscarAsync("/JogosDoUsuario/999/jogosfavoritos");
        string erro = response.Content.ReadAsStringAsync().Result;
        //Assert
        Assert.Equal(HttpStatusCode.InternalServerError, response.StatusCode);
        Assert.Contains("Usuário não encontrado.", erro);
    }
}
