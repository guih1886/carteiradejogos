using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;
using System.Net;
using System.Text.Json;
using Xunit.Abstractions;

namespace CarteiraDeJogosTest.ControllersTest;

public class JogosControllerTest
{
    private HttpClientBuilder _httpClient = new HttpClientBuilder();
    private ITestOutputHelper _outputHelper;

    public JogosControllerTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    [Fact]
    public async void CadastrarJogosTest()
    {
        //Arrange
        CreateJogosDto novoJogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 1, "1994", "PS4", 9);
        //Act
        HttpResponseMessage response = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", novoJogo);
        ReadJogosDto jogo = JsonSerializer.Deserialize<ReadJogosDto>(response.Content.ReadAsStringAsync().Result)!;
        _outputHelper.WriteLine(jogo.ToString());
        //Assert
        Assert.Equal(1, jogo.Ativo);
        Assert.Equal("Jogo Teste", jogo.Nome);
        await _httpClient.DeletarAsync($"/Jogos/{jogo.Id}");
    }

    [Fact]
    public async void AdicionarJogoNaListaDoUsuarioAoCadastrarJogoTest()
    {
        //Arrange
        CreateJogosDto novoJogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 1, "1994", "PS4", 9);
        HttpResponseMessage responseJogo = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", novoJogo);
        ReadJogosDto jogoCadastrado = JsonSerializer.Deserialize<ReadJogosDto>(responseJogo.Content.ReadAsStringAsync().Result)!;
        HttpResponseMessage responseUsuario = await _httpClient.BuscarAsync($"/Usuarios/1");
        ReadUsuariosDto usuario = JsonSerializer.Deserialize<ReadUsuariosDto>(responseUsuario.Content.ReadAsStringAsync().Result)!;
        //Act
        bool jogoNaLista = usuario.Jogos.Contains(jogoCadastrado.Id);
        //Assert
        Assert.True(jogoNaLista);
        await _httpClient.DeletarAsync($"/Jogos/{jogoCadastrado.Id}");
    }

    [Fact]
    public async void CadastrarJogoComUsuarioIdIncorretoTest()
    {
        //Arrange
        CreateJogosDto jogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 0, "1994", "PS4", 9);
        //Act
        HttpResponseMessage response = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", jogo);
        _outputHelper.WriteLine(response.Content.ReadAsStringAsync().Result);
        //Assert
        Assert.Contains("Erro ao localizar o usuário", response.Content.ReadAsStringAsync().Result);
    }

    [Fact]
    public async void AlterarJogosTest()
    {
        //Arrange
        CreateJogosDto novoJogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 1, "1994", "PS4", 9);
        UpdateJogosDto jogo = new UpdateJogosDto("Endereço Teste", "Jogo Alterado", "Descrição de Teste alterada para o modelo.", Genero.Ação, "1994", "PS4", 9);
        //Act
        HttpResponseMessage response = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", novoJogo);
        ReadJogosDto jogoCadastrado = JsonSerializer.Deserialize<ReadJogosDto>(response.Content.ReadAsStringAsync().Result)!;
        HttpResponseMessage responseJogoAlterado = await _httpClient.AlterarAsync($"/Jogos/{jogoCadastrado.Id}", jogo);
        ReadJogosDto jogoAlterado = JsonSerializer.Deserialize<ReadJogosDto>(responseJogoAlterado.Content.ReadAsStringAsync().Result)!;
        _outputHelper.WriteLine(jogoAlterado.ToString());
        //Assert
        Assert.Equal("Jogo Alterado", jogoAlterado.Nome);
        await _httpClient.DeletarAsync($"/Jogos/{jogoAlterado.Id}");
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
        CreateJogosDto novoJogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 1, "1994", "PS4", 9);
        //Act
        HttpResponseMessage response = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", novoJogo);
        ReadJogosDto jogo = JsonSerializer.Deserialize<ReadJogosDto>(response.Content.ReadAsStringAsync().Result)!;
        HttpResponseMessage resultado = await _httpClient.BuscarAsync($"/Jogos/{jogo.Id}");
        ReadJogosDto jogoBuscado = JsonSerializer.Deserialize<ReadJogosDto>(resultado.Content.ReadAsStringAsync().Result!)!;
        _outputHelper.WriteLine(jogoBuscado.ToString());
        //Assert
        Assert.Equal(jogoBuscado.Id, jogo.Id);
        await _httpClient.DeletarAsync($"/Jogos/{jogo.Id}");
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
        CreateJogosDto jogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 1, "1994", "PS4", 9);
        //Act
        HttpResponseMessage response = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", jogo);
        ReadJogosDto jogoCriado = JsonSerializer.Deserialize<ReadJogosDto>(response.Content.ReadAsStringAsync().Result)!;
        HttpResponseMessage deleteResponse = await _httpClient.DeletarAsync($"/Jogos/{jogoCriado.Id}");
        _outputHelper.WriteLine(deleteResponse.ToString());
        //Assert
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
    }

    [Fact]
    public async void DeletarJogoDaListaDoUsuarioTest()
    {
        //Arrange
        CreateJogosDto novoJogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 1, "1994", "PS4", 9);
        //Act
        HttpResponseMessage responseJogo = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", novoJogo);
        ReadJogosDto jogoCadastrado = JsonSerializer.Deserialize<ReadJogosDto>(responseJogo.Content.ReadAsStringAsync().Result)!;

        HttpResponseMessage responseUsuario = await _httpClient.BuscarAsync($"/Usuarios/{novoJogo.UsuarioId}");
        ReadUsuariosDto usuario = JsonSerializer.Deserialize<ReadUsuariosDto>(responseUsuario.Content.ReadAsStringAsync().Result)!;
        usuario.JogosFavoritos.Add(jogoCadastrado.Id);
        HttpResponseMessage deleteResponse = await _httpClient.DeletarAsync($"/Jogos/{jogoCadastrado.Id}");

        HttpResponseMessage responseUsuario2 = await _httpClient.BuscarAsync($"/Usuarios/{novoJogo.UsuarioId}");
        ReadUsuariosDto usuario2 = JsonSerializer.Deserialize<ReadUsuariosDto>(responseUsuario2.Content.ReadAsStringAsync().Result)!;
        bool estaNaLista = usuario2.Jogos.Contains(jogoCadastrado.Id);
        bool estaNaListaFavoritos = usuario2.Jogos.Contains(jogoCadastrado.Id);
        //Assert
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
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
}
