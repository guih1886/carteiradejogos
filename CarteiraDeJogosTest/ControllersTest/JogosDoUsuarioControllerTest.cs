using CarteiraDeJogos.Controllers;
using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;
using CarteiraDeJogosTest.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace CarteiraDeJogosTest.ControllersTest;

public class JogosDoUsuarioControllerTest
{
    private ITestOutputHelper _outputHelper;
    private JogosDoUsuarioController _jogosDoUsuarioController;
    private JogosController _jogosController;
    private UsuarioController _usuarioController;

    public JogosDoUsuarioControllerTest(ITestOutputHelper outputHelper)
    {
        _outputHelper = outputHelper;
        _jogosDoUsuarioController = new JogosDoUsuarioServiceProvider().AdicionarServico();
        _jogosController = new JogosServiceProvider().AdicionarServico();
        _usuarioController = new UsuarioServiceProvider().AdicionarServico();
    }
    [Fact]
    public void AdicionaJogoFavoritoAoUsuarioTest()
    {
        //Arrange
        ReadJogosDto jogo = CriarJogo();
        //Act
        ObjectResult resposta = _jogosDoUsuarioController.AdicionarJogoFavoritoUsuario(1, jogo.Id);
        List<int> lista = JsonConvert.DeserializeObject<List<int>>(resposta.Value.ToString());
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.Contains(jogo.Id, lista);
        DeletarJogo(jogo);
    }
    [Fact]
    public void NaoAdicionaJogoFavoritoQueJaEstaNaListaTest()
    {
        //Arrange
        ReadJogosDto jogo = CriarJogo();
        //Act
        _jogosDoUsuarioController.AdicionarJogoFavoritoUsuario(1, jogo.Id);
        Thread.Sleep(500);
        ObjectResult resposta = _jogosDoUsuarioController.AdicionarJogoFavoritoUsuario(1, jogo.Id);
        //Assert
        Assert.Equal(400, resposta.StatusCode);
        Assert.Equal("Jogo já está na lista.", resposta.Value);
        DeletarJogo(jogo);
    }
    [Fact]
    public void NaoAdicionaJogoFavoritoQueNaoEstaNaListaDeJogosTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _jogosDoUsuarioController.AdicionarJogoFavoritoUsuario(1, 0);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Jogo não está na lista de jogos.", resposta.Value);
    }
    [Fact]
    public void NaoAdicionaJogoFavoritoEmUsuarioIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _jogosDoUsuarioController.AdicionarJogoFavoritoUsuario(0, 0);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Usuário não encontrado.", resposta.Value);
    }
    [Fact]
    public void ListaOsJogosTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _jogosDoUsuarioController.ListarTodosOsJogos(1);
        List<int> lista = JsonConvert.DeserializeObject<List<int>>(resposta.Value.ToString());
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.IsType<List<int>>(lista);
    }
    [Fact]
    public void NaoListaOsJogosUsuarioIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult response = _jogosDoUsuarioController.ListarTodosOsJogos(0);
        //Assert
        Assert.Equal(404, response.StatusCode);
        Assert.Contains("Usuário não encontrado.", response.Value.ToString());
    }
    [Fact]
    public void ListaOsJogosFavoritosTest()
    {
        //Arrange
        //Act
        ObjectResult response = _jogosDoUsuarioController.ListarJogosFavoritos(1);
        List<int> lista = JsonConvert.DeserializeObject<List<int>>(response.Value.ToString());
        //Assert
        Assert.Equal(200, response.StatusCode);
        Assert.IsType<List<int>>(lista);
    }
    [Fact]
    public void NaoListaOsJogosFavoritosUsuarioIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult response = _jogosDoUsuarioController.ListarJogosFavoritos(0);
        //Assert
        Assert.Equal(404, response.StatusCode);
        Assert.Contains("Usuário não encontrado.", response.Value.ToString());
    }
    [Fact]
    public void RemoveJogoDoUsuarioTest()
    {
        //Arrange
        ReadJogosDto jogo = CriarJogo();
        //Act
        _jogosDoUsuarioController.AdicionarJogoFavoritoUsuario(1, jogo.Id);
        ObjectResult resposta = _jogosDoUsuarioController.RemoverJogoUsuario(1, jogo.Id);
        ObjectResult respostaUsuario = _usuarioController.BuscarUsuarioPorId(1);
        ReadUsuariosDto usuariosDto = JsonConvert.DeserializeObject<ReadUsuariosDto>(respostaUsuario.Value.ToString());
        ObjectResult respostaJogo = _jogosController.BuscarJogoPorId(1);
        //Assert
        Assert.Equal(204, resposta.StatusCode);
        Assert.Equal(404, respostaJogo.StatusCode);
        Assert.Equal("Jogo não encontrado.", respostaJogo.Value.ToString());
        Assert.DoesNotContain(jogo.Id, usuariosDto.Jogos);
        Assert.DoesNotContain(jogo.Id, usuariosDto.JogosFavoritos);
        DeletarJogo(jogo);
    }
    [Fact]
    public void NaoRemoveJogoDoUsuarioIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _jogosDoUsuarioController.RemoverJogoUsuario(0, 0);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Usuário não encontrado.", resposta.Value.ToString());
    }
    [Fact]
    public void NaoRemoveJogoDoUsuarioQueNaoEstaNaListaTest()
    {
        //Arrange
        ReadJogosDto jogo = CriarJogo();
        //Act
        ObjectResult resposta = _jogosDoUsuarioController.RemoverJogoUsuario(2, jogo.Id);
        //Assert
        Assert.Equal(400, resposta.StatusCode);
        Assert.Equal("Jogo não está na lista.", resposta.Value.ToString());
        DeletarJogo(jogo);

    }
    [Fact]
    public void RemoveJogoFavoritoDoUsuarioTest()
    {
        //Arrange
        ReadJogosDto jogo = CriarJogo();
        //Act
        _jogosDoUsuarioController.AdicionarJogoFavoritoUsuario(1, jogo.Id);
        ObjectResult resposta = _jogosDoUsuarioController.RemoverJogoFavoritoUsuario(1, jogo.Id);
        //Assert
        Assert.Equal(204, resposta.StatusCode);
        DeletarJogo(jogo);
    }
    [Fact]
    public void NaoRemoveJogoFavoritoDoUsuarioIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _jogosDoUsuarioController.RemoverJogoFavoritoUsuario(0, 0);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Usuário não encontrado.", resposta.Value.ToString());
    }
    [Fact]
    public void NaoRemoveJogoFavoritoDoUsuarioQueNaoEstaNaListaTest()
    {
        //Arrange
        ReadJogosDto jogo = CriarJogo();
        //Act
        ObjectResult resposta = _jogosDoUsuarioController.RemoverJogoFavoritoUsuario(1, jogo.Id);
        //Assert
        Assert.Equal(400, resposta.StatusCode);
        Assert.Equal("Jogo não está na lista.", resposta.Value.ToString());
        DeletarJogo(jogo);
    }

    private ReadJogosDto CriarJogo()
    {
        CreateJogosDto jogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 1, "1994", "PS4", 9);
        ObjectResult resposta = _jogosController.CadastrarJogo(jogo);
        ReadJogosDto jogosDto = JsonConvert.DeserializeObject<ReadJogosDto>(resposta.Value.ToString()!)!;
        _outputHelper.WriteLine($"Jogo {jogosDto.Id} criado com sucesso.");
        return jogosDto;
    }
    private void DeletarJogo(ReadJogosDto jogo)
    {
        _jogosController.DeletarJogo(jogo.Id);
        _outputHelper.WriteLine($"Jogo deletado {jogo.Id} com sucesso.");
    }
}
