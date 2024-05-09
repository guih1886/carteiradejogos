using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraDeJogos.Controllers;

[ApiController]
[Route("Usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioRepository _usuarioRepository;

    public UsuarioController(UsuarioRepository usuarioRepository)
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

    [HttpPut("{id}")]
    public ActionResult<ReadUsuariosDto> AlterarUsuario(int id, [FromBody] UpdateUsuariosDto usuario)
    {
        ReadUsuariosDto usuarioAtualizado = _usuarioRepository.AtualizarUsuario(id, usuario);
        return Ok(usuarioAtualizado);
    }

    [HttpDelete("{id}")]
    public ActionResult DeletarUsuario(int id)
    {
        if (_usuarioRepository.DeletarUsuario(id)) return NoContent();
        return NotFound();
    }
}