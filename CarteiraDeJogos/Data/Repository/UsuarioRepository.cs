using AutoMapper;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Models;

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

        public ReadUsuariosDto AtualizarUsuario(int id, UpdateUsuariosDto usuarioDto)
        {
            Usuario? usuario = BuscarUsuario(id);
            _mapper.Map(usuario, usuarioDto);
            _context.SaveChanges();
            return _mapper.Map<ReadUsuariosDto>(usuario);
        }

        public ReadUsuariosDto BuscarUsuarioPorId(int id)
        {
            Usuario? usuario = BuscarUsuario(id);
            return _mapper.Map<ReadUsuariosDto>(usuario);
        }

        public ReadUsuariosDto CadastrarUsuario(CreateUsuarioDto usuarioDto)
        {
            Usuario novoUsuario = _mapper.Map<Usuario>(usuarioDto);
            novoUsuario.Jogos = [];
            novoUsuario.JogosFavoritos = [];
            _context.Usuarios.Add(novoUsuario);
            _context.SaveChanges();
            return _mapper.Map<ReadUsuariosDto>(novoUsuario);
        }

        public bool DeletarUsuario(int id)
        {
            Usuario? usuario = BuscarUsuario(id);
            if (usuario == null) return false;
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return true;
        }

        public List<ReadUsuariosDto> ListarUsuarios()
        {
            return _mapper.Map<List<ReadUsuariosDto>>(_context.Usuarios.ToList());
        }

        public void AdicionarJogoUsuario(int usuarioId, int id)
        {
            Usuario? usuario = BuscarUsuario(usuarioId);
            if (usuario == null) throw new Exception("Usuário não encontrado.");
            if (!usuario.Jogos!.Contains(id)) usuario.Jogos.Add(id);
        }

        private Usuario? BuscarUsuario(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }
    }
}
