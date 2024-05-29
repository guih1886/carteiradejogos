using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDeJogos.Controllers;

[ApiController]
[Route("Login")]
public class LoginController : ControllerBase
{
    private readonly ITokenService _tokenService;
    private ObjectResult httpResponse = new ObjectResult("");

    public LoginController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    public ObjectResult EfetuarLogin([FromBody] LoginUsuarioDto usuario)
    {
        string resposta = _tokenService.GerarToken(usuario);
        if (string.IsNullOrEmpty(usuario.Email))
        {
            httpResponse.StatusCode = 401;
            httpResponse.Value = "E-mail não pode estar vazio.";
            return httpResponse;
        }
        if (string.IsNullOrEmpty(usuario.Senha))
        {
            httpResponse.StatusCode = 401;
            httpResponse.Value = "A senha deve ser informada.";
            return httpResponse;
        }
        if (resposta == "E-mail ou senha inválido.")
        {
            httpResponse.StatusCode = 401;
            httpResponse.Value = "E-mail ou senha inválido.";
            return httpResponse;
        }
        httpResponse.StatusCode = 200;
        httpResponse.Value = resposta;
        return httpResponse;
    }
}