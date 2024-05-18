using CarteiraDeJogos.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDeJogos.Controllers;

[ApiController]
[Route("JogosDoUsuario/{id}")]
public class JogosDoUsuarioController : ControllerBase
{
    private readonly IJogosRepository _jogosRepository;
    private readonly IJogosDoUsuarioRepository _jogosDoUsuarioRepository;
    private ObjectResult httpResponse = new ObjectResult("");

    public JogosDoUsuarioController(IJogosDoUsuarioRepository jogosDoUsuarioRepository, IJogosRepository jogosRepository)
    {
        _jogosDoUsuarioRepository = jogosDoUsuarioRepository;
        _jogosRepository = jogosRepository;
    }

    [HttpGet("todosJogos")]
    public ObjectResult ListarTodosOsJogos(int id)
    {
        string response = _jogosDoUsuarioRepository.ListarTodosOsJogos(id);
        if (response == "Usuário não encontrado.")
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = response;
            return httpResponse;
        }
        httpResponse.StatusCode = 200;
        httpResponse.Value = response;
        return httpResponse;
    }

    [HttpGet("jogosfavoritos")]
    public ObjectResult ListarJogosFavoritos(int id)
    {
        string response = _jogosDoUsuarioRepository.ListarJogosFavoritos(id);
        if (response == "Usuário não encontrado.")
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = response;
            return httpResponse;
        }
        httpResponse.StatusCode = 200;
        httpResponse.Value = response;
        return httpResponse;
    }
    [Authorize]
    [HttpPost("adicionarJogoFavorito/{idJogoFavorito}")]
    public ObjectResult AdicionarJogoFavoritoUsuario(int id, int idJogoFavorito)
    {
        string response = _jogosDoUsuarioRepository.AdicionarJogoAoFavoritoDoUsuario(id, idJogoFavorito);
        if (response == "Usuário não encontrado.")
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = response;
            return httpResponse;
        }
        if (response == "Jogo já está na lista.")
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = response;
            return httpResponse;
        }
        if (response == "Jogo não está na lista de jogos.")
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = response;
            return httpResponse;
        }
        httpResponse.StatusCode = 200;
        httpResponse.Value = response;
        return httpResponse;
    }
    [Authorize]
    [HttpDelete("removerJogo/{idJogo}")]
    public ObjectResult RemoverJogoUsuario(int id, int idJogo)
    {
        string response = _jogosDoUsuarioRepository.RemoverJogoDoUsuario(id, idJogo)!;
        if (response == "Usuário não encontrado.")
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = response;
            return httpResponse;
        }
        if (response == "Jogo não encontrado.")
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = response;
            return httpResponse;
        }
        if (response == "Jogo não está na lista.")
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = response;
            return httpResponse;
        }
        
        httpResponse.StatusCode = 204;
        return httpResponse;
    }
    [Authorize]
    [HttpDelete("removerJogoFavorito/{idJogoFavorito}")]
    public ObjectResult RemoverJogoFavoritoUsuario(int id, int idJogoFavorito)
    {
        string response = _jogosDoUsuarioRepository.RemoverJogoFavoritoDoUsuario(id, idJogoFavorito)!;
        if (response == "Usuário não encontrado.")
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = response;
            return httpResponse;
        }
        if (response == "Jogo não está na lista.")
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = response;
            return httpResponse;
        }
        if (response == "Jogo não está na lista.")
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = response;
            return httpResponse;
        }
        httpResponse.StatusCode = 204;
        return httpResponse;
    }
    [HttpPost("ativarJogo/{idJogo}")]
    public ObjectResult AtivarJogo(int id, int idJogo)
    {
        string response = _jogosRepository.AtivarJogo(id, idJogo);
        if (response == "Usuário não encontrado.")
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = response;
            return httpResponse;
        }
        if (response == "Jogo não encontrado.")
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = response;
            return httpResponse;
        }
        if (response == "Jogo não pertence ao usuário.")
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = response;
            return httpResponse;
        }
        if (response == "Jogo já está ativo.")
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = response;
            return httpResponse;
        }
        httpResponse.StatusCode = 200;
        httpResponse.Value = response;
        return httpResponse;
    }
}