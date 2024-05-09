using AutoMapper;
using CarteiraDeJogos.Data;
using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Repository;
using CarteiraDeJogos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDeJogos.Controllers
{
    [ApiController]
    [Route("Jogos")]
    public class JogosController : ControllerBase
    {
        private readonly JogosRepository _repository;

        public JogosController(JogosRepository repository)
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
                return BadRequest($"Erro ao cadastrar o jogo. {error.Message}");
            }
        }

        [HttpPut("{id}")]
        public ActionResult<ReadJogosDto> AtualizarJogo(int id, [FromBody] UpdateJogosDto jogo)
        {

            ReadJogosDto jogoAtualizado = _repository.AtualizarJogo(id, jogo);
            if (jogoAtualizado == null) return NotFound();
            return Ok(jogoAtualizado);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarJogo(int id)
        {
            if (_repository.DeletarJogo(id)) return NoContent();
            return NotFound();
        }
    }
}