using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Models;
using System.Net;
using System.Text;
using System.Text.Json;
using Xunit.Abstractions;

namespace CarteiraDeJogosTest.ControllersTest;

public class JogosControllerTest
{
    private HttpClient _httpClient = new HttpClient();
    private string baseUrl = "http://localhost:5020";
    private static int idDoJogo = 0;
    private ITestOutputHelper _outputHelper;

    public JogosControllerTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
    }

    #region "Crud de Jogos"

    [Fact]
    public async void A_CadastrarJogosTest()
    {
        //Arrange
        CreateJogosDto jogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 1, "1994", "PS4", 9);
        string json = JsonSerializer.Serialize(jogo);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        //Act
        HttpResponseMessage response = await _httpClient.PostAsync(baseUrl + "/Jogos", httpContent);
        string resultado = response.Content.ReadAsStringAsync().Result.ToString();
        ReadJogosDto jogoCadastrado = JsonSerializer.Deserialize<ReadJogosDto>(resultado)!;
        idDoJogo = jogoCadastrado.Id;
        _outputHelper.WriteLine(idDoJogo.ToString());
        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("Jogo Teste", resultado);
        Assert.Contains("Ação", resultado);
    }

    [Fact]
    public async void AlterarJogosTest()
    {
        //Arrange
        UpdateJogosDto jogo = new UpdateJogosDto("Endereço Teste", "Jogo Alterado", "Descrição de Teste alterada para o modelo.", Genero.Ação, "1994", "PS4", 9);
        string json = JsonSerializer.Serialize(jogo);
        HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");
        //Act
        HttpResponseMessage response = await _httpClient.PutAsync(baseUrl + "/Jogos/" + idDoJogo, httpContent);
        string resultado = response.Content.ReadAsStringAsync().Result.ToString();
        ReadJogosDto jogoAlterado = JsonSerializer.Deserialize<ReadJogosDto>(resultado)!;
        _outputHelper.WriteLine(jogoAlterado.Nome);
        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal("Jogo Alterado", jogoAlterado.Nome);
    }

    [Fact]
    public async void ListarJogosTest()
    {
        //Arrange
        //Act
        HttpResponseMessage resultado = await _httpClient.GetAsync(baseUrl + "/Jogos");
        //Assert        
        Assert.True(resultado.StatusCode == HttpStatusCode.OK);
    }

    [Fact]
    public async void B_ListarJogosPorIdTest()
    {
        //Arrange
        //Act
        HttpResponseMessage resultado = await _httpClient.GetAsync(baseUrl + "/Jogos/" + idDoJogo);
        _outputHelper.WriteLine(baseUrl + "/Jogos/" + idDoJogo);
        ReadJogosDto jogo = JsonSerializer.Deserialize<ReadJogosDto>(resultado.Content.ReadAsStringAsync().Result.ToString())!;
        //Assert
        Assert.Equal(idDoJogo, jogo.Id);
    }

    [Fact]
    public async void Z_DeletarJogosTest()
    {
        //Arrange
        //Act
        _outputHelper.WriteLine(baseUrl + $"/Jogos/" + idDoJogo);
        HttpResponseMessage resultado = await _httpClient.DeleteAsync(baseUrl + $"/Jogos/{idDoJogo}");
        //Assert
        Assert.Equal(HttpStatusCode.NoContent, resultado.StatusCode);
    }

    #endregion

    #region "Demais Testes"



    #endregion
}
