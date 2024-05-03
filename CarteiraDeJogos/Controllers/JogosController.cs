﻿using AutoMapper;
using CarteiraDeJogos.Data;
using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDeJogos.Controllers
{
    [ApiController]
    [Route("Jogos")]
    public class JogosController : ControllerBase
    {
        private JogosContext _context;
        private IMapper _mapper;

        public JogosController(JogosContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ListarJogos()
        {
            List<ReadJogosDto> jogos = _mapper.Map<List<ReadJogosDto>>(_context.Jogos.ToList());
            return Ok(jogos);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarJogoPorId(int id)
        {
            Jogos? jogo = Utils.BuscarJogos(id, _context);
            if (jogo == null) return NotFound();
            return Ok(_mapper.Map<ReadJogosDto>(jogo));

        }

        [HttpPost]
        public IActionResult CadastrarJogo([FromBody] CreateJogosDto jogo)
        {
            Jogos novoJogo = _mapper.Map<Jogos>(jogo);
            _context.Jogos.Add(novoJogo);
            _context.SaveChanges();
            return Ok(_mapper.Map<ReadJogosDto>(novoJogo));
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarJogo(int id, [FromBody] UpdateJogosDto jogo)
        {
            Jogos? jogoAtualizado = Utils.BuscarJogos(id, _context);
            if (jogoAtualizado == null) return NotFound();
            _mapper.Map(jogo, jogoAtualizado);
            _context.SaveChanges();
            return Ok(_mapper.Map<ReadJogosDto>(jogoAtualizado));
        }

        [HttpDelete("{id}")]
        public IActionResult DeletarJogo(int id)
        {
            Jogos? jogo = Utils.BuscarJogos(id, _context);
            if (jogo == null) return NotFound();
            _context.Jogos.Remove(jogo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
