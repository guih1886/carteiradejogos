using CarteiraDeJogos.Data;
using CarteiraDeJogos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDeJogos.Controllers;

[ApiController]
[Route("Usuarios")]
public class UsuarioController : ControllerBase
{
    private JogosContext _context;

    public UsuarioController(JogosContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult CadastraUsuario([FromBody] Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return Ok();
    }
}
