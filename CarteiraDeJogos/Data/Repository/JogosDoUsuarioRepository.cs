using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Models;

namespace CarteiraDeJogos.Data.Repository;

public class JogosDoUsuarioRepository : IJogosDoUsuarioRepository
{
    private JogosContext _context;
    private UsuarioRepository _usuarioRepository;
    private JogosRepository _jogosRepository;

    public JogosDoUsuarioRepository(JogosContext context, UsuarioRepository usuarioRepository, JogosRepository jogosRepository)
    {
        _context = context;
        _usuarioRepository = usuarioRepository;
        _jogosRepository = jogosRepository;
    }

    public string? AdicionarJogoAoFavoritoDoUsuario(int usuarioId, int idJogoFavorito)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) return "Usuário não encontrado.";
        if (usuario.JogosFavoritos!.Contains(idJogoFavorito)) return "Jogo já está na lista.";
        if (!usuario.Jogos!.Contains(idJogoFavorito)) return "Jogo não está na lista de jogos.";
        _usuarioRepository.AdicionarJogoFavorito(usuario.Id, idJogoFavorito);
        return usuario.JogosFavoritos.ToString();
    }
    public string? ListarTodosOsJogos(int usuarioId)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) return "Usuário não encontrado.";
        return usuario.Jogos.ToString();
    }
    public string? ListarJogosFavoritos(int usuarioId)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) return "Usuário não encontrado.";
        return usuario.JogosFavoritos.ToString();
    }
    public string RemoverJogoDoUsuario(int usuarioId, int idJogo)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) return "Usuário não encontrado.";
        if (!usuario.Jogos!.Contains(idJogo)) return "Jogo não está na lista.";
        _usuarioRepository.RemoverJogo(usuario.Id, idJogo);
        Jogos? jogo = _jogosRepository.BuscarJogo(idJogo);
        jogo!.Ativo = 0;
        _context.SaveChanges();
        return "Ok";
    }
    public string RemoverJogoFavoritoDoUsuario(int usuarioId, int idJogoFavorito)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) return "Usuário não encontrado.";
        if (!usuario.JogosFavoritos!.Contains(idJogoFavorito)) return "Jogo não está na lista.";
        _usuarioRepository.RemoverJogoFavorito(usuario.Id, idJogoFavorito);
        _context.SaveChanges();
        return "Ok";
    }
}