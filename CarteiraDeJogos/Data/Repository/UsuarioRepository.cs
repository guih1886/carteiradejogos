using AutoMapper;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Models;
using System.Linq;

namespace CarteiraDeJogos.Data.Repository
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private JogosContext _context;
        private IMapper _mapper;

        public UsuarioRepository(JogosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Usuario? BuscarUsuario(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }
        public ReadUsuariosDto BuscarUsuarioPorId(int id)
        {
            Usuario? usuario = BuscarUsuario(id);
            return _mapper.Map<ReadUsuariosDto>(usuario);
        }
        public Usuario? BuscarUsuarioEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }
        public List<ReadUsuariosDto> ListarUsuarios()
        {
            return _mapper.Map<List<ReadUsuariosDto>>(_context.Usuarios.ToList());
        }
        public List<int>? ListarTodosOsJogos(int usuarioId)
        {
            Usuario usuario = BuscarUsuario(usuarioId)!;
            return usuario.Jogos;
        }
        public List<int>? ListarJogosFavoritos(int usuarioId)
        {
            Usuario usuario = BuscarUsuario(usuarioId)!;
            return usuario.JogosFavoritos;
        }
        public ReadUsuariosDto CadastrarUsuario(CreateUsuarioDto usuarioDto)
        {
            Usuario? novoUsuario = _mapper.Map<Usuario>(usuarioDto);
            novoUsuario.Jogos = [];
            novoUsuario.JogosFavoritos = [];
            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();
            return _mapper.Map<ReadUsuariosDto>(novoUsuario);
        }
        public ReadUsuariosDto AtualizarUsuario(int id, UpdateUsuariosDto usuarioDto)
        {
            Usuario? usuario = BuscarUsuario(id);
            _mapper.Map(usuarioDto, usuario);
            _context.SaveChanges();
            return _mapper.Map<ReadUsuariosDto>(usuario);
        }
        public bool DeletarUsuario(int id)
        {
            Usuario? usuario = BuscarUsuario(id);
            if (usuario == null) return false;
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }
        public List<int> AdicionarJogoUsuario(int usuarioId, int id)
        {
            Usuario usuario = BuscarUsuario(usuarioId)!;
            if (!usuario.Jogos!.Contains(id)) usuario.Jogos.Add(id);
            _context.SaveChanges();
            return usuario.Jogos;
        }
        public List<int> AdicionarJogoFavorito(int usuarioId, int idJogoFavorito)
        {
            Usuario usuario = BuscarUsuario(usuarioId)!;
            if (!usuario.JogosFavoritos!.Contains(idJogoFavorito)) usuario.JogosFavoritos.Add(idJogoFavorito);
            _context.SaveChanges();
            return usuario.JogosFavoritos;
        }
        public bool RemoverJogo(int usuarioId, int idJogo)
        {
            Jogos jogo = _context.Jogos.FirstOrDefault(jogo => jogo.Id == idJogo)!;
            Usuario usuario = BuscarUsuario(usuarioId)!;
            if (usuario.Jogos!.Contains(jogo.Id)) usuario.Jogos.Remove(idJogo);
            if (usuario.JogosFavoritos!.Contains(jogo.Id)) usuario.JogosFavoritos.Remove(idJogo);
            jogo.Ativo = 0;
            _context.SaveChanges();
            return true;
        }
        public bool RemoverJogoFavorito(int usuarioId, int idJogo)
        {
            Usuario usuario = BuscarUsuario(usuarioId)!;
            if (usuario.JogosFavoritos!.Contains(idJogo)) usuario.JogosFavoritos.Remove(idJogo);
            _context.SaveChanges();
            return true;
        }
    }
}
