using AutoMapper;
using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Models;
using System.Net;

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

        public ReadJogosDto CadastrarJogo(CreateJogosDto jogo)
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
                throw new Exception("Erro ao cadastrar o jogo.");
            }
        }
        public ReadJogosDto AtualizarJogo(int id, UpdateJogosDto jogoNovo)
        {
            try
            {
                Jogos? jogo = BuscarJogoAtivo(id);
                Jogos jogoAtualizado = _mapper.Map(jogoNovo, jogo)!;
                _context.SaveChanges();
                return _mapper.Map<ReadJogosDto>(jogoAtualizado);
            }
            catch (Exception)
            {
                throw new Exception("Erro ao atualizar o jogo.");
            }
        }
        public List<ReadJogosDto> ListarJogos()
        {
            List<ReadJogosDto> jogos = _mapper.Map<List<ReadJogosDto>>(_context.Jogos.Where(jogo => jogo.Ativo == 1).ToList());
            return jogos;
        }
        public Jogos? BuscarJogoAtivo(int id)
        {
            return _context.Jogos.FirstOrDefault(j => j.Id == id && j.Ativo == 1);
        }
        private Jogos? BuscarJogoInativo(int id)
        {
            return _context.Jogos.FirstOrDefault(jogo => jogo.Id == id);
        }
        public ReadJogosDto BuscarJogoPorId(int id)
        {
            Jogos? jogo = BuscarJogoAtivo(id);
            return _mapper.Map<ReadJogosDto>(jogo);
        }
        public bool DeletarJogo(int id)
        {
            try
            {
                Jogos? jogo = BuscarJogoAtivo(id);
                if (jogo == null) return false;
                //Caso encontre o jogo, muda ele para inativo, e retira ele das listas dos usuários.
                jogo.Ativo = 0;
                ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(jogo.UsuarioId);
                UpdateUsuariosDto usuarioAlterado = _mapper.Map<UpdateUsuariosDto>(usuario);
                if (usuarioAlterado.Jogos.Contains(jogo.Id)) usuarioAlterado.Jogos.Remove(jogo.Id);
                if (usuarioAlterado.JogosFavoritos.Contains(jogo.Id)) usuarioAlterado.JogosFavoritos.Remove(jogo.Id);
                _usuarioRepository.AtualizarUsuario(usuario.Id, usuarioAlterado);
                return true;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao deletar o jogo.");
            }
        }
        public HttpResponseMessage AtivarJogo(int id, int idJogo)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(id);
            if (usuario == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Content = new StringContent("Usuário não encontrado.");
                return response;
            }
            Jogos? jogo = BuscarJogoInativo(idJogo);
            if (jogo == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Content = new StringContent("Jogo não encontrado.");
                return response;
            }
            if (jogo.UsuarioId != usuario.Id)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent("Jogo não pertence ao usuário.");
                return response;
            }
            if (jogo.Ativo == 1)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Content = new StringContent("Jogo já está ativo.");
                return response;
            }
            jogo.Ativo = 1;
            _context.SaveChanges();
            _usuarioRepository.AdicionarJogoUsuario(id, idJogo);
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}
