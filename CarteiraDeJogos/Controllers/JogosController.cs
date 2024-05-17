using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarteiraDeJogos.Controllers
{
    [ApiController]
    [Route("Jogos")]
    public class JogosController : ControllerBase
    {
        private readonly IJogosRepository _repository;

        public JogosController(IJogosRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<ReadJogosDto>> ListarJogos()
        {
            List<ReadJogosDto> jogos = _repository.ListarJogos();
            return Ok(jogos);
        }
        [HttpGet("{id}")]
        public IActionResult BuscarJogoPorId(int id)
        {
            ReadJogosDto jogo = _repository.BuscarJogoPorId(id);
            if (jogo == null) return NotFound();
            return Ok(jogo);
        }
        [Authorize]
        [HttpPost]
        public ActionResult<ReadJogosDto> CadastrarJogo([FromBody] CreateJogosDto jogo)
        {
            try
            {
                ReadJogosDto novoJogo = _repository.CadastrarJogo(jogo);
                return Ok(novoJogo);
            }
            catch (Exception error)
            {
                return BadRequest($"Erro ao localizar o usuário com o id {jogo.UsuarioId} + {error.Message}.");
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public ActionResult<ReadJogosDto> AtualizarJogo(int id, [FromBody] UpdateJogosDto jogo)
        {
            ReadJogosDto jogoAtualizado = _repository.AtualizarJogo(id, jogo);
            if (jogoAtualizado == null) return NotFound();
            return Ok(jogoAtualizado);
        }
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeletarJogo(int id)
        {
            if (_repository.DeletarJogo(id)) return NoContent();
            return NotFound();
        }
    }
}