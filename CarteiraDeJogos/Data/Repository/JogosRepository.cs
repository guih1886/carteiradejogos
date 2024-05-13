﻿using AutoMapper;
using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Models;

namespace CarteiraDeJogos.Data.Repository
{
    public class JogosRepository : IJogosRepository
    {
        private JogosContext _context;
        private IMapper _mapper;
        private UsuarioRepository _usuarioRepository;

        public JogosRepository(JogosContext context, IMapper mapper, UsuarioRepository usuarioRepository)
        {
            _context = context;
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
        }

        public List<ReadJogosDto> ListarJogos()
        {
            List<ReadJogosDto> jogos = _mapper.Map<List<ReadJogosDto>>(_context.Jogos.Where(jogo => jogo.Ativo == 1).ToList());
            return jogos;
        }

        public ReadJogosDto BuscarJogoPorId(int id)
        {
            Jogos? jogo = BuscarJogo(id);
            return _mapper.Map<ReadJogosDto>(jogo);
        }

        public ReadJogosDto CadastrarJogo(CreateJogosDto jogo)
        {
            Jogos novoJogo = _mapper.Map<Jogos>(jogo);
            novoJogo.Ativo = 1;
            _context.Jogos.Add(novoJogo);
            _context.SaveChanges();
            _usuarioRepository.AdicionarJogoUsuario(novoJogo.UsuarioId, novoJogo.Id);
            _context.SaveChanges();
            return _mapper.Map<ReadJogosDto>(novoJogo);
        }

        public ReadJogosDto AtualizarJogo(int id, UpdateJogosDto jogoNovo)
        {
            Jogos? jogo = BuscarJogo(id);
            Jogos jogoAtualizado = _mapper.Map(jogoNovo, jogo)!;
            _context.SaveChanges();
            return _mapper.Map<ReadJogosDto>(jogoAtualizado);
        }

        public bool DeletarJogo(int id)
        {
            Jogos? jogo = BuscarJogo(id);
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

        public Jogos? BuscarJogo(int id)
        {
            return _context.Jogos.FirstOrDefault(j => j.Id == id && j.Ativo == 1);
        }
    }
}
