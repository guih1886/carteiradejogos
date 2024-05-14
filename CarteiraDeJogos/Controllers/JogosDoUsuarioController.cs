using CarteiraDeJogos.Data;
using CarteiraDeJogos.Data.Repository;
using CarteiraDeJogos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarteiraDeJogos.Controllers;

[ApiController]
[Route("JogosDoUsuario/{id}")]
public class JogosDoUsuarioController : ControllerBase
{
    private readonly JogosDoUsuarioRepository _jogosDoUsuarioRepository;

    public JogosDoUsuarioController(JogosDoUsuarioRepository jogosDoUsuarioRepository)
    {
        _jogosDoUsuarioRepository = jogosDoUsuarioRepository;
    }

    [HttpGet("todosJogos")]
    public ActionResult<List<int>> ListarTodosOsJogos(int id)
    {
        List<int> listaDeJogos = _jogosDoUsuarioRepository.ListarTodosOsJogos(id);
        return Ok(listaDeJogos);
    }

    [HttpGet("jogosfavoritos")]
    public ActionResult<List<int>> ListarJogosFavoritos(int id)
    {
        List<int> jogosFavoritos = _jogosDoUsuarioRepository.ListarJogosFavoritos(id);
        return Ok(jogosFavoritos);
    }

    [HttpPost("adicionarJogoFavorito/{idJogoFavorito}")]
    public ActionResult<List<int>> AdicionarJogoFavoritoUsuario(int id, int idJogoFavorito)
    {
        List<int> jogosFavoritos = _jogosDoUsuarioRepository.AdicionarJogoAoFavoritoDoUsuario(id, idJogoFavorito);
        return Ok(jogosFavoritos);
    }

    [HttpDelete("removerJogo/{idJogo}")]
    public ActionResult<List<int>> RemoverJogoUsuario(int id, int idJogo)
    {
        _jogosDoUsuarioRepository.RemoverJogoDoUsuario(id, idJogo);
        return NoContent();
    }

    [HttpDelete("removerJogoFavorito/{idJogoFavorito}")]
    public IActionResult RemoverJogoFavoritoUsuario(int id, int idJogoFavorito)
    {
        _jogosDoUsuarioRepository.RemoverJogoFavoritoDoUsuario(id, idJogoFavorito);
        return NoContent();
    }
}


