using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarteiraDeJogos.Controllers
{
    [ApiController]
    [Route("Jogos")]
    public class JogosController : ControllerBase
    {
        private readonly IJogosRepository _repository;
        private ObjectResult httpResponse = new ObjectResult("");

        public JogosController(IJogosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ObjectResult ListarJogos()
        {
            List<ReadJogosDto> jogos = _repository.ListarJogos();
            httpResponse.StatusCode = 200;
            httpResponse.Value = jogos;
            return httpResponse;
        }
        [HttpGet("{id}")]
        public ObjectResult BuscarJogoPorId(int id)
        {
            ReadJogosDto jogo = _repository.BuscarJogoPorId(id);
            if (jogo == null)
            {
                httpResponse.StatusCode = 404;
                httpResponse.Value = "Jogo não encontrado.";
                return httpResponse;
            }
            string json = JsonConvert.SerializeObject(jogo);
            httpResponse.StatusCode = 200;
            httpResponse.Value = json;
            return httpResponse;
        }
        [Authorize]
        [HttpPost]
        public ObjectResult CadastrarJogo([FromBody] CreateJogosDto jogo)
        {
            ReadJogosDto? novoJogo = _repository.CadastrarJogo(jogo);
            if (novoJogo == null)
            {
                httpResponse.StatusCode = 400;
                httpResponse.Value = $"Erro ao localizar o usuário com o id {jogo.UsuarioId}.";
                return httpResponse;
            }
            string json = JsonConvert.SerializeObject(novoJogo);
            httpResponse.StatusCode = 200;
            httpResponse.Value = json;
            return httpResponse;
        }
        [Authorize]
        [HttpPut("{id}")]
        public ObjectResult AtualizarJogo(int id, [FromBody] UpdateJogosDto jogo)
        {
            ReadJogosDto? jogoAtualizado = _repository.AtualizarJogo(id, jogo);
            if (jogoAtualizado == null)
            {
                httpResponse.StatusCode = 404;
                httpResponse.Value = "Jogo não encontrado.";
                return httpResponse;
            }
            string json = JsonConvert.SerializeObject(jogoAtualizado);
            httpResponse.StatusCode = 200;
            httpResponse.Value = json;
            return httpResponse;
        }
        [Authorize]
        [HttpDelete("{id}")]
        public ObjectResult DeletarJogo(int id)
        {
            if (!_repository.DeletarJogo(id))
            {
                httpResponse.StatusCode = 404;
                httpResponse.Value = "Jogo não encontrado.";
                return httpResponse;
            }
            httpResponse.StatusCode = 204;
            httpResponse.Value = "Jogo excluido com sucesso.";
            return httpResponse;
        }
    }
}