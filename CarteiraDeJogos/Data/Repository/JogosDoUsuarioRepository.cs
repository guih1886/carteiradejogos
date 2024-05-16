using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using System.Net;
using System.Text;
using System.Text.Json;

namespace CarteiraDeJogos.Data.Repository;

public class JogosDoUsuarioRepository : IJogosDoUsuarioRepository
{
    private IUsuariosRepository _usuarioRepository;
    public JogosDoUsuarioRepository(IUsuariosRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public HttpResponseMessage AdicionarJogoAoFavoritoDoUsuario(int usuarioId, int idJogoFavorito)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Content = new StringContent("Usuário não encontrado.");
            return response;
        }
        if (usuario.JogosFavoritos.Contains(idJogoFavorito))
        {
            response.StatusCode = HttpStatusCode.BadRequest;
            response.Content = new StringContent("Jogo já está na lista.");
            return response;
        }
        if (!usuario.Jogos.Contains(idJogoFavorito))
        {
            response.StatusCode = HttpStatusCode.BadRequest;
            response.Content = new StringContent("Jogo não está na lista de jogos.");
            return response;
        }
        _usuarioRepository.AdicionarJogoFavorito(usuario.Id, idJogoFavorito);
        response.StatusCode = HttpStatusCode.OK;
        ReadUsuariosDto usuarioNovo = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        string json = JsonSerializer.Serialize(usuarioNovo.JogosFavoritos);
        response.Content = new StringContent(json, Encoding.UTF8, "application/json");
        return response;
    }
    public HttpResponseMessage ListarTodosOsJogos(int usuarioId)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Content = new StringContent("Usuário não encontrado.");
            return response;
        }
        response.StatusCode = HttpStatusCode.OK;
        string json = JsonSerializer.Serialize(usuario.Jogos);
        response.Content = new StringContent(json, Encoding.UTF8, "application/json");
        return response;
    }
    public HttpResponseMessage ListarJogosFavoritos(int usuarioId)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Content = new StringContent("Usuário não encontrado.");
            return response;
        }
        response.StatusCode = HttpStatusCode.OK;
        string json = JsonSerializer.Serialize(usuario.JogosFavoritos);
        response.Content = new StringContent(json, Encoding.UTF8, "application/json");
        return response;
    }
    public HttpResponseMessage RemoverJogoDoUsuario(int usuarioId, int idJogo)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Content = new StringContent("Usuário não encontrado.");
            return response;
        }
        if (!usuario.Jogos!.Contains(idJogo))
        {
            response.StatusCode = HttpStatusCode.BadRequest;
            response.Content = new StringContent("Jogo não está na lista.");
            return response;
        }
        _usuarioRepository.RemoverJogo(usuario.Id, idJogo);
        response.StatusCode = HttpStatusCode.NoContent;
        return response;
    }
    public HttpResponseMessage RemoverJogoFavoritoDoUsuario(int usuarioId, int idJogoFavorito)
    {
        HttpResponseMessage response = new HttpResponseMessage();
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null)
        {
            response.StatusCode = HttpStatusCode.NotFound;
            response.Content = new StringContent("Usuário não encontrado.");
            return response;

        }
        if (!usuario.JogosFavoritos!.Contains(idJogoFavorito))
        {
            response.StatusCode = HttpStatusCode.BadRequest;
            response.Content = new StringContent("Jogo não está na lista.");
            return response;
        }
        _usuarioRepository.RemoverJogoFavorito(usuario.Id, idJogoFavorito);
        response.StatusCode = HttpStatusCode.NoContent;
        return response;
    }
}