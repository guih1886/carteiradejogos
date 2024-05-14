﻿using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using CarteiraDeJogos.Models;

namespace CarteiraDeJogos.Data.Repository;

public class JogosDoUsuarioRepository : IJogosDoUsuarioRepository
{
    private JogosContext _context;
    private UsuarioRepository _usuarioRepository;
    private JogosRepository _jogosRepository;

    public JogosDoUsuarioRepository(JogosContext context, UsuarioRepository usuarioRepository, JogosRepository jogosRepository)
    {
        _context = context;
        _usuarioRepository = usuarioRepository;
        _jogosRepository = jogosRepository;
    }

    public List<int> AdicionarJogoAoFavoritoDoUsuario(int usuarioId, int idJogoFavorito)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) throw new Exception("Usuário não encontrado.");
        if (usuario.JogosFavoritos!.Contains(idJogoFavorito)) throw new Exception("Jogo já está na lista.");
        if (!usuario.Jogos!.Contains(idJogoFavorito)) throw new Exception("Jogo não está na lista de jogos.");
        _usuarioRepository.AdicionarJogoFavorito(usuario.Id, idJogoFavorito);
        return usuario.JogosFavoritos;
    }

    public List<int> ListarTodosOsJogos(int usuarioId)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) throw new Exception("Usuário não encontrado.");
        List<int> todosOsJogos = usuario.Jogos.ToList();
        return todosOsJogos;
    }

    public List<int> ListarJogosFavoritos(int usuarioId)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) throw new Exception("Usuário não encontrado.");
        List<int> jogosFavoritos = usuario.JogosFavoritos.ToList();
        return jogosFavoritos;
    }

    public void RemoverJogoDoUsuario(int usuarioId, int idJogo)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) throw new Exception("Usuário não encontrado.");
        if (!usuario.Jogos!.Contains(idJogo)) throw new Exception("Jogo não está na lista.");
        _usuarioRepository.RemoverJogo(usuario.Id, idJogo);
        Jogos? jogo = _jogosRepository.BuscarJogo(idJogo);
        jogo!.Ativo = 0;
        _context.SaveChanges();
    }

    public void RemoverJogoFavoritoDoUsuario(int usuarioId, int idJogoFavorito)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(usuarioId);
        if (usuario == null) throw new Exception("Usuário não encontrado.");
        if (!usuario.JogosFavoritos!.Contains(idJogoFavorito)) throw new Exception("Jogo não está na lista.");
        _usuarioRepository.RemoverJogoFavorito(usuario.Id, idJogoFavorito);
        _context.SaveChanges();
    }
}
