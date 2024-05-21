using CarteiraDeJogos.Controllers;
using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;
using CarteiraDeJogosTest.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace CarteiraDeJogosTest.ControllersTest;

public class JogosControllerTest
{
    private JogosController _jogosController;
    private UsuarioController _usuarioController;
    private JogosDoUsuarioController _jogosDoUsuarioController;
    private ITestOutputHelper _outputHelper;

    public JogosControllerTest(ITestOutputHelper outputHelper)
    {
        _jogosController = new JogosServiceProvider().AdicionarServico();
        _usuarioController = new UsuarioServiceProvider().AdicionarServico();
        _jogosDoUsuarioController = new JogosDoUsuarioServiceProvider().AdicionarServico();
        _outputHelper = outputHelper;
    }

    [Fact]
    public void CadastrarJogosTest()
    {
        //Arrange
        CreateJogosDto jogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 1, "1994", "PS4", 9);
        ObjectResult resposta = _jogosController.CadastrarJogo(jogo);
        ReadJogosDto jogosDto = JsonConvert.DeserializeObject<ReadJogosDto>(resposta.Value.ToString()!)!;
        //Act
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.Equal(1, jogosDto.Ativo);
        Assert.IsType<ReadJogosDto>(jogosDto);
        DeletarJogo(jogosDto);
    }
    [Fact]
    public void AdicionarJogoNaListaDoUsuarioAoCadastrarJogoTest()
    {
        //Arrange
        ReadJogosDto jogo = CriarJogo();
        ObjectResult resposta = _usuarioController.BuscarUsuarioPorId(1);
        ReadUsuariosDto usuario = JsonConvert.DeserializeObject<ReadUsuariosDto>(resposta.Value!.ToString()!)!;
        //Act
        //Assert
        Assert.Contains(jogo.Id, usuario.Jogos);
        DeletarJogo(jogo);
    }
    [Fact]
    public void CadastrarJogoComUsuarioIdIncorretoTest()
    {
        //Arrange
        CreateJogosDto jogo = new CreateJogosDto("Endereço Teste", "Jogo Teste", "Descrição de Teste para o modelo.", Genero.Ação, 0, "1994", "PS4", 9);
        //Act
        ObjectResult resposta = _jogosController.CadastrarJogo(jogo);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal($"Erro ao localizar o usuário com o id {jogo.UsuarioId}.", resposta.Value);
    }
    [Fact]
    public void AlterarJogosTest()
    {
        //Arrange
        ReadJogosDto jogo = CriarJogo();
        UpdateJogosDto jogoAlterado = new UpdateJogosDto("Endereço Teste", "Jogo Alterado", "Descrição de Teste alterada para o modelo.", Genero.Ação, "1994", "PS4", 9);
        //Act
        ObjectResult response = _jogosController.AtualizarJogo(jogo.Id, jogoAlterado);
        ReadJogosDto jogoDto = JsonConvert.DeserializeObject<ReadJogosDto>(response.Value!.ToString()!)!;
        //Assert
        Assert.Equal(200, response.StatusCode);
        Assert.Equal("Jogo Alterado", jogoDto.Nome);
        Assert.IsType<ReadJogosDto>(jogoDto);
        DeletarJogo(jogo);
    }
    [Fact]
    public void AlterarJogoIncorrretoTest()
    {
        //Arrange
        UpdateJogosDto jogoAlterado = new UpdateJogosDto("Endereço Teste", "Jogo Alterado", "Descrição de Teste alterada para o modelo.", Genero.Ação, "1994", "PS4", 9);
        //Act
        ObjectResult response = _jogosController.AtualizarJogo(0, jogoAlterado);
        //Assert
        Assert.Equal(404, response.StatusCode);
        Assert.Equal("Jogo não encontrado.", response.Value);
    }
    [Fact]
    public void ListarJogosTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _jogosController.ListarJogos();
        //Assert        
        Assert.Equal(200, resposta.StatusCode);
    }
    [Fact]
    public void ListarJogosPorIdTest()
    {
        //Arrange
        ReadJogosDto jogo = CriarJogo();
        //Act
        ObjectResult resposta = _jogosController.BuscarJogoPorId(jogo.Id);
        ReadJogosDto jogoBuscado = JsonConvert.DeserializeObject<ReadJogosDto>(resposta.Value!.ToString()!)!;
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.IsType<ReadJogosDto>(jogoBuscado);
        DeletarJogo(jogo);
    }
    [Fact]
    public void ListarJogosPorIdIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _jogosController.BuscarJogoPorId(0);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Jogo não encontrado.", resposta.Value);
    }
    [Fact]
    public void DeletarJogosTest()
    {
        //Arrange
        ReadJogosDto jogo = CriarJogo();
        //Act
        ObjectResult resposta = _jogosController.DeletarJogo(jogo.Id);
        //Assert
        Assert.Equal(204, resposta.StatusCode);
        Assert.Equal("Jogo excluido com sucesso.", resposta.Value);
    }
    [Fact]
    public void DeletarJogosIncorretoTest()
    {
        //Arrange
        //Act
        ObjectResult resposta = _jogosController.DeletarJogo(0);
        //Assert
        Assert.Equal(404, resposta.StatusCode);
        Assert.Equal("Jogo não encontrado.", resposta.Value);
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
