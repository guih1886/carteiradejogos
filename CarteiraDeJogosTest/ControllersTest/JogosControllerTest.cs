using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Models;
using System.Net;
using System.Text;
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
        string response = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", novoJogo);
        ReadJogosDto jogo = JsonSerializer.Deserialize<ReadJogosDto>(response)!;
        _outputHelper.WriteLine(jogo.ToString());
        //Assert
        Assert.Equal(1, jogo.Ativo);
        Assert.Equal("Jogo Teste", jogo.Nome);
        await _httpClient.DeletarAsync($"/Jogos/{jogo.Id}");
    }

    [Fact]
    public async void CadastrarJogoComUsuarioIdIncorretoTest()
    {
        //Arrange
        CreateJogosDto jogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 0, "1994", "PS4", 9);
        //Act
        string response = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", jogo);
        _outputHelper.WriteLine(response);
        //Assert
        Assert.Contains("Erro ao localizar o usuário", response);
    }

    [Fact]
    public async void AlterarJogosTest()
    {
        //Arrange
        CreateJogosDto novoJogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 1, "1994", "PS4", 9);
        UpdateJogosDto jogo = new UpdateJogosDto("Endereço Teste", "Jogo Alterado", "Descrição de Teste alterada para o modelo.", Genero.Ação, "1994", "PS4", 9);
        //Act
        string response = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", novoJogo);
        ReadJogosDto jogoCadastrado = JsonSerializer.Deserialize<ReadJogosDto>(response)!;
        string responseJogoAlterado = await _httpClient.AlterarAsync($"/Jogos/{jogoCadastrado.Id}", jogo);
        ReadJogosDto jogoAlterado = JsonSerializer.Deserialize<ReadJogosDto>(responseJogoAlterado)!;
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
        string response = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", novoJogo);
        ReadJogosDto jogo = JsonSerializer.Deserialize<ReadJogosDto>(response)!;
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
        string response = await _httpClient.CadastrarAsync<CreateJogosDto>("/Jogos", jogo);
        ReadJogosDto jogoCriado = JsonSerializer.Deserialize<ReadJogosDto>(response)!;
        HttpResponseMessage deleteResponse = await _httpClient.DeletarAsync($"/Jogos/{jogoCriado.Id}");
        _outputHelper.WriteLine(deleteResponse.ToString());
        //Assert
        Assert.Equal(HttpStatusCode.NoContent, deleteResponse.StatusCode);
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
