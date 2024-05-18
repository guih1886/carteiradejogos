using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using System.Text.Json;

namespace CarteiraDeJogos.Data.Repository;

public class JogosDoUsuarioRepository : IJogosDoUsuarioRepository
{
    private IUsuariosRepository _usuarioRepository;
    public JogosDoUsuarioRepository(IUsuariosRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public string AdicionarJogoAoFavoritoDoUsuario(int usuarioId, int idJogoFavorito)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) return "Usuário não encontrado.";
        if (usuario.JogosFavoritos.Contains(idJogoFavorito)) return "Jogo já está na lista.";
        if (!usuario.Jogos.Contains(idJogoFavorito)) return "Jogo não está na lista de jogos.";
        List<int> lista = _usuarioRepository.AdicionarJogoFavorito(usuario.Id, idJogoFavorito);
        string json = JsonSerializer.Serialize(lista);
        return json;
    }
    public string ListarTodosOsJogos(int usuarioId)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) return "Usuário não encontrado.";
        string json = JsonSerializer.Serialize(usuario.Jogos);
        return json;
    }
    public string ListarJogosFavoritos(int usuarioId)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) return "Usuário não encontrado.";
        string json = JsonSerializer.Serialize(usuario.JogosFavoritos);
        return json;
    }
    public string? RemoverJogoDoUsuario(int usuarioId, int idJogo)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) return "Usuário não encontrado.";
        if (!usuario.Jogos.Contains(idJogo)) return "Jogo não está na lista.";
        string? resposta = _usuarioRepository.RemoverJogo(usuario.Id, idJogo);
        return resposta;
    }
    public string? RemoverJogoFavoritoDoUsuario(int usuarioId, int idJogoFavorito)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) return "Usuário não encontrado.";
        if (!usuario.JogosFavoritos!.Contains(idJogoFavorito)) return "Jogo não está na lista.";
        string? lista = _usuarioRepository.RemoverJogoFavorito(usuario.Id, idJogoFavorito);
        return lista;
    }
}