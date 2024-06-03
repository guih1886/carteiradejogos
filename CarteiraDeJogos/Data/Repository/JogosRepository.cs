using AutoMapper;
using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Models;

namespace CarteiraDeJogos.Data.Repository
{
    public class JogosRepository : IJogosRepository
    {
        private JogosContext _context;
        private IMapper _mapper;
        private IUsuariosRepository _usuarioRepository;

        public JogosRepository(JogosContext context, IMapper mapper, IUsuariosRepository usuarioRepository)
        {
            _context = context;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public ReadJogosDto? CadastrarJogo(CreateJogosDto jogo)
        {
            try
            {
                Jogos novoJogo = _mapper.Map<Jogos>(jogo);
                novoJogo.Ativo = 1;
                _context.Jogos.Add(novoJogo);
                _context.SaveChanges();
                _usuarioRepository.AdicionarJogoUsuario(novoJogo.UsuarioId, novoJogo.Id);
                return _mapper.Map<ReadJogosDto>(novoJogo);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public ReadJogosDto? AtualizarJogo(int id, UpdateJogosDto jogoNovo)
        {
            Jogos? jogo = BuscarJogo(id);
            if (jogo == null) return null;
            Jogos jogoAtualizado = _mapper.Map(jogoNovo, jogo)!;
            _context.SaveChanges();
            return _mapper.Map<ReadJogosDto>(jogoAtualizado);
        }
        public List<ReadJogosDto> ListarJogos()
        {
            List<ReadJogosDto> jogos = _mapper.Map<List<ReadJogosDto>>(_context.Jogos.ToList());
            return jogos;
        }
        public Jogos? BuscarJogo(int id)
        {
            return _context.Jogos.FirstOrDefault(j => j.Id == id);
        }
        public ReadJogosDto BuscarJogoPorId(int id)
        {
            Jogos? jogo = BuscarJogo(id);
            return _mapper.Map<ReadJogosDto>(jogo);
        }
        public bool DeletarJogo(int id)
        {
            Jogos? jogo = BuscarJogo(id);
            if (jogo == null) return false;
            //Caso encontre o jogo, muda ele para inativo, e retira ele das listas dos usuários.
            Usuario usuario = _usuarioRepository.BuscarUsuario(jogo.UsuarioId)!;
            _usuarioRepository.RemoverJogo(usuario.Id, jogo.Id);
            _usuarioRepository.RemoverJogoFavorito(usuario.Id, jogo.Id);
            _context.Remove(jogo);
            _context.SaveChanges();
            return true;
        }
        public ReadJogosDto AtivarJogo(int id, int idJogo)
        {           
            Jogos jogo = BuscarJogo(idJogo)!;
            jogo.Ativo = 1;
            _context.SaveChanges();
            _usuarioRepository.AdicionarJogoUsuario(id, idJogo);
            ReadJogosDto jogodto = _mapper.Map<ReadJogosDto>(jogo);
            return jogodto;
        }
    }
}