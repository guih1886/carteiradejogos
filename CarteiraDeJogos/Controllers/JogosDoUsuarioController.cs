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
        if (usuario == null) return NotFound("Usuario não encontrado.");
        if (usuario.Jogos == null) return NoContent();
        List<int> todosOsJogos = usuario.Jogos.ToList();
        return Ok(todosOsJogos);
    }

    [HttpGet("jogosfavoritos")]
    public IActionResult ListarJogosFavoritos(int id)
    {
        Usuario? usuario = Utils.BuscarUsuario(id, _context);
        if (usuario == null) return NotFound("Usuario não encontrado.");
        if (usuario.JogosFavoritos == null) return NoContent();
        List<int> jogosFavoritos = usuario.JogosFavoritos.ToList();
        return Ok(jogosFavoritos);
    }

    [HttpPost("adicionarJogo/{idJogo}")]
    public IActionResult AdicionarJogoUsuario(int id, int idJogo)
    {
        Usuario? usuario = Utils.BuscarUsuario(id, _context);
        if (usuario == null) return NotFound("Usuario não encontrado.");
        if (usuario.Jogos!.Contains(idJogo)) return BadRequest("Jogo já está na lista.");
        usuario.Jogos!.Add(idJogo);
        _context.SaveChanges();
        return Ok(usuario.Jogos);
    }

    [HttpPost("adicionarJogoFavorito/{idJogoFavorito}")]
    public IActionResult AdicionarJogoFavoritoUsuario(int id, int idJogoFavorito)
    {
        Usuario? usuario = Utils.BuscarUsuario(id, _context);
        if (usuario == null) return NotFound("Usuario não encontrado.");
        if (usuario.JogosFavoritos!.Contains(idJogoFavorito)) return BadRequest("Jogo já está na lista.");
        usuario.JogosFavoritos!.Add(idJogoFavorito);
        _context.SaveChanges();
        return Ok(usuario.JogosFavoritos);
    }

    [HttpDelete("removerJogo/{idJogo}")]
    public IActionResult RemoverJogoUsuario(int id, int idJogo)
    {
        Usuario? usuario = Utils.BuscarUsuario(id, _context);
        if (usuario == null) return NotFound("Usuario não encontrado.");
        if (!usuario.Jogos!.Contains(idJogo)) return BadRequest("Jogo não está na lista.");      
        usuario.Jogos!.Remove(idJogo);
        _context.SaveChanges();
        return Ok(usuario.Jogos);
    }

    [HttpDelete("removerJogoFavorito/{idJogoFavorito}")]
    public IActionResult RemoverJogoFavoritoUsuario(int id, int idJogoFavorito)
    {
        Usuario? usuario = Utils.BuscarUsuario(id, _context);
        if (usuario == null) return NotFound("Usuario não encontrado.");
        if (!usuario.JogosFavoritos!.Contains(idJogoFavorito)) return BadRequest("Jogo não está na lista.");
        usuario.JogosFavoritos!.Remove(idJogoFavorito);
        _context.SaveChanges();
        return Ok(usuario.JogosFavoritos);
    }
}
