using CarteiraDeJogos.Controllers;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogosTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDeJogosTest.ControllersTest;

public class LoginControllerTest
{
    private LoginController controller;

    public LoginControllerTest()
    {
        controller = new LoginServiceProvider().AdicionarServico();
    }

    [Fact]
    public void EfetuaLogin()
    {
        //Arrange
        LoginUsuarioDto loginDto = new LoginUsuarioDto("guilherme@email.com", "123456");
        //Act
        ObjectResult resposta = controller.EfetuarLogin(loginDto);
        //Assert
        Assert.Equal(200, resposta.StatusCode);
        Assert.Contains("eyJhbGciOiJIUz", resposta.Value.ToString());
    }
    [Fact]
    public void NaoEfetuaLoginComEmailIncorreto()
    {
        //Arrange
        LoginUsuarioDto loginDto = new LoginUsuarioDto("umemailincorretoaqui", "123456");
        //Act
        ObjectResult resposta = controller.EfetuarLogin(loginDto);
        //Assert
        Assert.Equal(401, resposta.StatusCode);
        Assert.Contains("E-mail ou senha inválido.", resposta.Value.ToString());
    }
    [Fact]
    public void NaoEfetuaLoginComSenhaIncorreta()
    {
        //Arrange
        LoginUsuarioDto loginDto = new LoginUsuarioDto("guilherme@gmail.com", "32sda6e89");
        //Act
        ObjectResult resposta = controller.EfetuarLogin(loginDto);
        //Assert
        Assert.Equal(401, resposta.StatusCode);
        Assert.Contains("E-mail ou senha inválido.", resposta.Value.ToString());
    }
    [Fact]
    public void NaoEfetuaLoginSemSenha()
    {
        //Arrange
        LoginUsuarioDto loginDto = new LoginUsuarioDto("guilherme@gmail.com", "");
        //Act
        ObjectResult resposta = controller.EfetuarLogin(loginDto);
        //Assert
        Assert.Equal(401, resposta.StatusCode);
        Assert.Contains("A senha deve ser informada.", resposta.Value.ToString());
    }
    [Fact]
    public void NaoEfetuaLoginSemEmail()
    {
        //Arrange
        LoginUsuarioDto loginDto = new LoginUsuarioDto("", "32sda6e89");
        //Act
        ObjectResult resposta = controller.EfetuarLogin(loginDto);
        //Assert
        Assert.Equal(401, resposta.StatusCode);
        Assert.Contains("E-mail não pode estar vazio.", resposta.Value.ToString());
    }
}
