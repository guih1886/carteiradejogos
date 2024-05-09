using CarteiraDeJogos.Data.Dto.Jogos;
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

    public List<int> AdicionarJogoAoFavoritoDoUsuario(int usuarioId, int idJogoFavorito)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) throw new Exception("Usuário não encontrado.");
        if (usuario.JogosFavoritos!.Contains(idJogoFavorito)) throw new Exception("Jogo já está na lista.");
        if (!usuario.Jogos!.Contains(idJogoFavorito)) throw new Exception("Jogo não está na lista de jogos.");
        usuario.JogosFavoritos!.Add(idJogoFavorito);
        _context.SaveChanges();
        return usuario.JogosFavoritos;
    }

    public List<int> ListarTodosOsJogos(int usuarioId)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) throw new Exception("Usuário não encontrado.");
        List<int> todosOsJogos = usuario.Jogos.ToList();
        return todosOsJogos;
    }

    public List<int> ListarJogosFavoritos(int usuarioId)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) throw new Exception("Usuário não encontrado.");
        List<int> jogosFavoritos = usuario.JogosFavoritos.ToList();
        return jogosFavoritos;
    }

    public List<int> RemoverJogoDoUsuario(int usuarioId, int idJogo)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) throw new Exception("Usuário não encontrado.");
        if (!usuario.Jogos!.Contains(idJogo)) throw new Exception("Jogo não está na lista.");
        usuario.Jogos!.Remove(idJogo);
        Jogos? jogo = _jogosRepository.BuscarJogo(usuarioId);
        jogo!.Ativo = 0;
        _context.SaveChanges();
        return usuario.Jogos;
    }

    public List<int> RemoverJogoFavoritoDoUsuario(int usuarioId, int idJogoFavorito)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) throw new Exception("Usuário não encontrado.");
        if (!usuario.Jogos!.Contains(idJogoFavorito)) throw new Exception("Jogo não está na lista.");
        usuario.JogosFavoritos!.Remove(idJogoFavorito);
        _context.SaveChanges();
        return usuario.JogosFavoritos;
    }
}
