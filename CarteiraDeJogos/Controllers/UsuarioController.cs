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
        return Ok(usuarios);
    }

    [HttpPost]
    public IActionResult CadastraUsuario([FromBody] Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return Ok();
    }
}
