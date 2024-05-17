using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDeJogos.Controllers;

[ApiController]
[Route("Usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuariosRepository _usuarioRepository;

    public UsuarioController(IUsuariosRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet]
    public ActionResult<List<ReadUsuariosDto>> ListarUsuarios()
    {
        List<ReadUsuariosDto> usuarios = _usuarioRepository.ListarUsuarios();
        return Ok(usuarios);
    }

    [HttpGet("{id}")]
    public ActionResult<ReadUsuariosDto> BuscarUsuarioPorId(int id)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(id);
        if (usuario == null) return NotFound();
        return Ok(usuario);
    }
    [HttpPost]
    public ActionResult<ReadUsuariosDto> CadastrarUsuario([FromBody] CreateUsuarioDto usuario)
    {
        ReadUsuariosDto usuarioNovo = _usuarioRepository.CadastrarUsuario(usuario);
        return Ok(usuarioNovo);
    }
    [Authorize]
    [HttpPut("{id}")]
    public ActionResult<ReadUsuariosDto> AlterarUsuario(int id, [FromBody] UpdateUsuariosDto usuario)
    {
        ReadUsuariosDto usuarioAtualizado = _usuarioRepository.AtualizarUsuario(id, usuario);
        if (usuarioAtualizado == null) return NotFound();
        return Ok(usuarioAtualizado);
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ActionResult DeletarUsuario(int id)
    {
        if (_usuarioRepository.DeletarUsuario(id)) return NoContent();
        return NotFound();
    }
}