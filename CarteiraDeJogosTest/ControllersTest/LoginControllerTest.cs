using CarteiraDeJogos.Data.Dto.Usuarios;
using System.Net;

namespace CarteiraDeJogosTest.ControllersTest;

public class LoginControllerTest
{
    private HttpClientBuilder _httpClientBuilder = new HttpClientBuilder();

    [Fact]
    public async void EfetuaLogin()
    {
        //Arrange
        LoginUsuarioDto loginDto = new LoginUsuarioDto("guilherme@gmail.com", "123456");
        //Act
        HttpResponseMessage response = await _httpClientBuilder.CadastrarAsync("/Login", loginDto);
        string mensagem = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Contains("eyJhbGciOiJIUz", mensagem);
    }
    [Fact]
    public async void NaoEfetuaLoginComEmailIncorreto()
    {
        //Arrange
        LoginUsuarioDto loginDto = new LoginUsuarioDto("umemailincorretoaqui", "123456");
        //Act
        HttpResponseMessage response = await _httpClientBuilder.CadastrarAsync("/Login", loginDto);
        string mensagem = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        Assert.Contains("E-mail ou senha inválido.", mensagem);
    }
    [Fact]
    public async void NaoEfetuaLoginComSenhaIncorreta()
    {
        //Arrange
        LoginUsuarioDto loginDto = new LoginUsuarioDto("guilherme@gmail.com", "32sda6e89");
        //Act
        HttpResponseMessage response = await _httpClientBuilder.CadastrarAsync("/Login", loginDto);
        string mensagem = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        Assert.Contains("E-mail ou senha inválido.", mensagem);
    }
    [Fact]
    public async void NaoEfetuaLoginSemSenha()
    {
        //Arrange
        LoginUsuarioDto loginDto = new LoginUsuarioDto("guilherme@gmail.com", "");
        //Act
        HttpResponseMessage response = await _httpClientBuilder.CadastrarAsync("/Login", loginDto);
        string mensagem = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Contains("A senha deve ser informada.", mensagem);
    }
    [Fact]
    public async void NaoEfetuaLoginSemEmail()
    {
        //Arrange
        LoginUsuarioDto loginDto = new LoginUsuarioDto("", "32sda6e89");
        //Act
        HttpResponseMessage response = await _httpClientBuilder.CadastrarAsync("/Login", loginDto);
        string mensagem = await response.Content.ReadAsStringAsync();
        //Assert
        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        Assert.Contains("E-mail não pode estar vazio.", mensagem);
    }
}
