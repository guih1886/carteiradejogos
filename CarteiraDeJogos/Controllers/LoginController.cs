using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDeJogos.Controllers;

[ApiController]
[Route("Login")]
public class LoginController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public LoginController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    public IActionResult EfetuarLogin([FromBody] LoginUsuarioDto usuario)
    {
        string resposta = _tokenService.GerarToken(usuario);
        if (resposta == "E-mail ou senha inválido.") return Unauthorized(resposta);
        return Ok(resposta);
    }
}