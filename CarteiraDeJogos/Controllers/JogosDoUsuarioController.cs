using CarteiraDeJogos.Data;
using CarteiraDeJogos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDeJogos.Controllers;

[ApiController]
[Route("JogosDoUsuario/{id}")]
public class JogosDoUsuarioController : ControllerBase
{
    private JogosContext _context;

    public JogosDoUsuarioController(JogosContext context)
    {
        _context = context;
    }

    [HttpGet("todosJogos")]
    public IActionResult ListarTodosOsJogos(int id)
    {
        Usuario? usuario = Utils.BuscarUsuario(id, _context);
        if (usuario == null) return NotFound();
        if (usuario.Jogos == null) return NoContent();
        List<int> todosOsJogos = usuario.Jogos.ToList();
        return Ok(todosOsJogos);
    }

    [HttpGet("jogosfavoritos")]
    public IActionResult ListarJogosFavoritos(int id)
    {
        Usuario? usuario = Utils.BuscarUsuario(id, _context);
        if (usuario == null) return NotFound();
        if (usuario.JogosFavoritos == null) return NoContent();
        List<int> jogosFavoritos = usuario.JogosFavoritos.ToList();
        return Ok(jogosFavoritos);
    }
}
