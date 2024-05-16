using CarteiraDeJogos.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarteiraDeJogos.Controllers;

[ApiController]
[Route("JogosDoUsuario/{id}")]
public class JogosDoUsuarioController : ControllerBase
{
    private readonly IJogosDoUsuarioRepository _jogosDoUsuarioRepository;

    public JogosDoUsuarioController(IJogosDoUsuarioRepository jogosDoUsuarioRepository)
    {
        _jogosDoUsuarioRepository = jogosDoUsuarioRepository;
    }

    [HttpGet("todosJogos")]
    public async Task<IActionResult> ListarTodosOsJogos(int id)
    {
        HttpResponseMessage response = _jogosDoUsuarioRepository.ListarTodosOsJogos(id);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            return NotFound(content);
        }
        return Ok(content);
    }

    [HttpGet("jogosfavoritos")]
    public async Task<IActionResult> ListarJogosFavoritos(int id)
    {
        HttpResponseMessage response = _jogosDoUsuarioRepository.ListarJogosFavoritos(id);
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            return NotFound(content);
        }
        return Ok(content);
    }

    [HttpPost("adicionarJogoFavorito/{idJogoFavorito}")]
    public async Task<IActionResult> AdicionarJogoFavoritoUsuario(int id, int idJogoFavorito)
    {
        HttpResponseMessage response = _jogosDoUsuarioRepository.AdicionarJogoAoFavoritoDoUsuario(id, idJogoFavorito);
        string content = await response.Content.ReadAsStringAsync();
        if (response.StatusCode == HttpStatusCode.NotFound) return NotFound(content);
        if (response.StatusCode == HttpStatusCode.BadRequest) return BadRequest(content);
        return Ok(content);
    }

    [HttpDelete("removerJogo/{idJogo}")]
    public async Task<IActionResult> RemoverJogoUsuario(int id, int idJogo)
    {
        HttpResponseMessage response = _jogosDoUsuarioRepository.RemoverJogoDoUsuario(id, idJogo);
        string content = await response.Content.ReadAsStringAsync();
        if (response.StatusCode == HttpStatusCode.NotFound) return NotFound(content);
        if (response.StatusCode == HttpStatusCode.BadRequest) return BadRequest(content);
        return NoContent();
    }

    [HttpDelete("removerJogoFavorito/{idJogoFavorito}")]
    public async Task<IActionResult> RemoverJogoFavoritoUsuario(int id, int idJogoFavorito)
    {
        HttpResponseMessage response = _jogosDoUsuarioRepository.RemoverJogoFavoritoDoUsuario(id, idJogoFavorito);
        string content = await response.Content.ReadAsStringAsync();
        if (response.StatusCode == HttpStatusCode.NotFound) return NotFound(content);
        if (response.StatusCode == HttpStatusCode.BadRequest) return BadRequest(content);
        return NoContent();
    }
}


