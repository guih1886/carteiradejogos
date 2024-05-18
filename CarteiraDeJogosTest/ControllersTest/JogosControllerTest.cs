using CarteiraDeJogos.Controllers;
using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;
using CarteiraDeJogosTest.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using Xunit.Abstractions;

namespace CarteiraDeJogosTest.ControllersTest;

public class JogosControllerTest
{
    private JogosController controller;

    public JogosControllerTest(ITestOutputHelper outputHelper)
    {
        controller = new JogosServiceProvider().AdicionarServico();
    }

    [Fact]
    public void CadastrarJogosTest()
    {
        //Arrange
        ReadJogosDto jogoLocal = jogo;
        ApagarJogoCriado();
        //Act
        //Assert
        Assert.Equal(1, jogoLocal.Ativo);
        Assert.Equal("Jogo Teste", jogoLocal.Nome);
    }
    [Fact]
    public async void AdicionarJogoNaListaDoUsuarioAoCadastrarJogoTest()
    {
        //Arrange
        HttpResponseMessage response = await _httpClient.BuscarAsync("/JogosDoUsuario/1/todosJogos");
        ApagarJogoCriado();
        string listaDeJogos = await response.Content.ReadAsStringAsync();
        List<int> lista = JsonConvert.DeserializeObject<List<int>>(listaDeJogos)!;
        //Act
        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    [Fact]
    public async void CadastrarJogoComUsuarioIdIncorretoTest()
    {
        //Arrange
        ApagarJogoCriado();
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
        ReadJogosDto jogoLocal = this.jogo;
        ApagarJogoCriado();
        UpdateJogosDto jogo = new UpdateJogosDto("Endereço Teste", "Jogo Alterado", "Descrição de Teste alterada para o modelo.", Genero.Ação, "1994", "PS4", 9);
        //Act
        HttpResponseMessage responseJogoAlterado = await _httpClient.AlterarAsync($"/Jogos/{jogoLocal.Id}", jogo);
        ReadJogosDto jogoAlterado = JsonConvert.DeserializeObject<ReadJogosDto>(await responseJogoAlterado.Content.ReadAsStringAsync())!;
        //Assert
        Assert.Equal("Jogo Alterado", jogoAlterado.Nome);
    }
    [Fact]
    public void ListarJogosTest()
    {
        //Arrange
        ApagarJogoCriado();
        //Act
        ObjectResult resultado = controller.ListarJogos();
        //Assert        
        Assert.Equal(200, resultado.StatusCode);
    }
    [Fact]
    public async void ListarJogosPorIdTest()
    {
        //Arrange
        ReadJogosDto jogoLocal = jogo;
        //Act
        ApagarJogoCriado();
        HttpResponseMessage resultado = await _httpClient.BuscarAsync($"/Jogos/{jogoLocal.Id}");
        ReadJogosDto jogoBuscado = JsonConvert.DeserializeObject<ReadJogosDto>(await resultado.Content.ReadAsStringAsync())!;
        //Assert
        Assert.Equal(jogoBuscado.Id, jogoLocal.Id);
    }
    [Fact]
    public async void ListarJogosPorIdIncorretoTest()
    {
        //Arrange
        ApagarJogoCriado();
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
    public async void DeletarJogoFavoritoAoDeletarJogoTest()
    {
        //Arrange
        ReadJogosDto jogoLocal = jogo;
        //Act
        await _httpClient.IncluirJogoNosFavoritos(1, jogoLocal.Id);
        await _httpClient.DeletarAsync($"/Jogos/{jogoLocal.Id}");
        HttpResponseMessage response = await _httpClient.BuscarAsync("/Usuarios/1");
        string content = await response.Content.ReadAsStringAsync();
        ReadUsuariosDto usuarioDto = JsonConvert.DeserializeObject<ReadUsuariosDto>(content)!;
        bool estaNaLista = usuarioDto.Jogos.Contains(jogo.Id);
        bool estaNaListaFavoritos = usuarioDto.Jogos.Contains(jogo.Id);
        ApagarJogoCriado();
        //Assert
        Assert.False(estaNaLista);
        Assert.False(estaNaListaFavoritos);
    }
    [Fact]
    public async void DeletarJogosIncorretoTest()
    {
        //Arrange
        ApagarJogoCriado();
        //Act
        HttpResponseMessage deleteResponse = await _httpClient.DeletarAsync($"/Jogos/0");
        //Assert
        Assert.Equal(HttpStatusCode.NotFound, deleteResponse.StatusCode);
    }

    private async void ApagarJogoCriado()
    {
        _outputHelper.WriteLine($"Apagando jogo {this.jogo.Id}");
        await _httpClient.DeletarAsync($"/Jogos/{jogo.Id}");
    }
    private async void ApagarJogoListaDeFavorito(int idJogoFavorito)
    {
        _outputHelper.WriteLine($"Apagando jogo favorito {idJogoFavorito}");
        await _httpClient.DeletarAsync($"/JogosDoUsuario/1/removerJogoFavorito/{idJogoFavorito}");
    }
}
