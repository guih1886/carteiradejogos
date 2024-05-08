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
            List<ReadJogosDto> jogos = _mapper.Map<List<ReadJogosDto>>(_context.Jogos.Where(jogo => jogo.Ativo == 1).ToList());
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
            try
            {
                Jogos novoJogo = _mapper.Map<Jogos>(jogo);
                novoJogo.Ativo = 1;
                _context.Jogos.Add(novoJogo);
                _context.SaveChanges();
                Utils.AdicionarJogoUsuario(jogo.UsuarioId, novoJogo.Id, _context);
                return Ok(_mapper.Map<ReadJogosDto>(novoJogo));
            }
            catch (Exception)
            {
                return BadRequest($"Erro ao cadastrar o jogo, verifique o Id do usuário.");
            }
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
            List<Usuario>? usuarios = Utils.ListarUsuarios(_context);
            if (jogo == null) return NotFound();
            jogo.Ativo = 0;
            foreach (var usuario in usuarios)
            {
                if (usuario.Jogos!.Contains(jogo.Id)) usuario.Jogos.Remove(jogo.Id);
                if (usuario.JogosFavoritos!.Contains(jogo.Id)) usuario.JogosFavoritos.Remove(jogo.Id);
            }
            _context.SaveChanges();
            return NoContent();
        }
    }
}
