using AutoMapper;
using CarteiraDeJogos.Data;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDeJogos.Controllers;

[ApiController]
[Route("Usuarios")]
public class UsuarioController : ControllerBase
{
    private JogosContext _context;
    private IMapper _mapper;

    public UsuarioController(JogosContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult ListarUsuarios()
    {
        List<ReadUsuariosDto> usuarios = _mapper.Map<List<ReadUsuariosDto>>(_context.Usuarios.ToList());
        if (usuarios == null) return NoContent();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarUsuarioPorId(int id)
    {
        Usuario? usuario = Utils.BuscarUsuario(id, _context);
        if (usuario == null) return NotFound();
        ReadUsuariosDto usuarioId = _mapper.Map<ReadUsuariosDto>(usuario);
        return Ok(usuarioId);
    }

    [HttpPost]
    public IActionResult CadastrarUsuario([FromBody] CreateUsuarioDto usuario)
    {
        Usuario novoUsuario = _mapper.Map<Usuario>(usuario);
        novoUsuario.Jogos = [];
        novoUsuario.JogosFavoritos = [];
        _context.Usuarios.Add(novoUsuario);
        _context.SaveChanges();
        return Ok(_mapper.Map<ReadUsuariosDto>(novoUsuario));
    }

    [HttpPut("{id}")]
    public IActionResult AlterarUsuario(int id, [FromBody] UpdateUsuariosDto usuario)
    {
        Usuario? usuarioId = Utils.BuscarUsuario(id, _context);
        _mapper.Map(usuario, usuarioId);
        _context.SaveChanges();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletarUsuario(int id)
    {
        Usuario? usuario = Utils.BuscarUsuario(id, _context);
        if (usuario == null) return NotFound();
        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();
        return NoContent();
    }
}