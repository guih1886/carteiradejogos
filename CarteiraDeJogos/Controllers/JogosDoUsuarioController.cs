using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarteiraDeJogos.Controllers;

[ApiController]
[Route("JogosDoUsuario/{id}")]
public class JogosDoUsuarioController : ControllerBase
{
    private readonly IJogosRepository _jogosRepository;
    private readonly IUsuariosRepository _usuariosRepository;
    private ObjectResult httpResponse = new ObjectResult("");

    public JogosDoUsuarioController(IJogosRepository jogosRepository, IUsuariosRepository usuariosRepository)
    {
        _jogosRepository = jogosRepository;
        _usuariosRepository = usuariosRepository;
    }

    [HttpGet("todosJogos")]
    public ObjectResult ListarTodosOsJogos(int id)
    {
        Usuario? usuario = _usuariosRepository.BuscarUsuario(id);
        if (usuario == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Usuário não encontrado.";
            return httpResponse;
        }
        string json = JsonConvert.SerializeObject(usuario.Jogos);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
    [HttpGet("jogosfavoritos")]
    public ObjectResult ListarJogosFavoritos(int id)
    {
        Usuario? usuario = _usuariosRepository.BuscarUsuario(id);
        if (usuario == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Usuário não encontrado.";
            return httpResponse;
        }
        string json = JsonConvert.SerializeObject(usuario.JogosFavoritos);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
    [Authorize]
    [HttpPost("adicionarJogoFavorito/{idJogoFavorito}")]
    public ObjectResult AdicionarJogoFavoritoUsuario(int id, int idJogoFavorito)
    {
        Usuario? usuario = _usuariosRepository.BuscarUsuario(id);
        if (usuario == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Usuário não encontrado.";
            return httpResponse;
        }
        if (!usuario.Jogos!.Contains(idJogoFavorito))
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Jogo não está na lista de jogos.";
            return httpResponse;
        }
        if (usuario.JogosFavoritos!.Contains(idJogoFavorito))
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = "Jogo já está na lista.";
            return httpResponse;
        }
        _usuariosRepository.AdicionarJogoFavorito(usuario.Id, idJogoFavorito);
        string json = JsonConvert.SerializeObject(usuario.JogosFavoritos);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
    [Authorize]
    [HttpDelete("removerJogo/{idJogo}")]
    public ObjectResult RemoverJogoUsuario(int id, int idJogo)
    {
        Usuario? usuario = _usuariosRepository.BuscarUsuario(id);
        Jogos? jogo = _jogosRepository.BuscarJogo(idJogo);
        if (usuario == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Usuário não encontrado.";
            return httpResponse;
        }
        if (jogo == null)
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = "Jogo não encontrado.";
            return httpResponse;
        }
        if (!usuario.Jogos!.Contains(idJogo))
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = "Jogo não está na lista.";
            return httpResponse;
        }
        _usuariosRepository.RemoverJogo(usuario.Id, jogo.Id);
        httpResponse.StatusCode = 204;
        return httpResponse;
    }
    [Authorize]
    [HttpDelete("removerJogoFavorito/{idJogoFavorito}")]
    public ObjectResult RemoverJogoFavoritoUsuario(int id, int idJogoFavorito)
    {
        Usuario? usuario = _usuariosRepository.BuscarUsuario(id);
        if (usuario == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Usuário não encontrado.";
            return httpResponse;
        }
        if (!usuario.JogosFavoritos!.Contains(idJogoFavorito))
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = "Jogo não está na lista.";
            return httpResponse;
        }
        _usuariosRepository.RemoverJogoFavorito(usuario.Id, idJogoFavorito);
        httpResponse.StatusCode = 204;
        return httpResponse;
    }
    [HttpPost("ativarJogo/{idJogo}")]
    public ObjectResult AtivarJogo(int id, int idJogo)
    {
        Jogos? jogo = _jogosRepository.BuscarJogo(idJogo);
        if (jogo == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Jogo não encontrado.";
            return httpResponse;
        }
        Usuario? buscaUsuario = _usuariosRepository.BuscarUsuario(id);
        if (buscaUsuario == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Usuário não encontrado.";
            return httpResponse;
        }
        if (jogo.UsuarioId != id)
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = "Jogo não pertence ao usuário.";
            return httpResponse;
        }
        if (jogo.Ativo == 1)
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = "Jogo já está ativo.";
            return httpResponse;
        }
        ReadJogosDto jogoAtivado = _jogosRepository.AtivarJogo(id, idJogo);
        string json = JsonConvert.SerializeObject(jogoAtivado);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
}