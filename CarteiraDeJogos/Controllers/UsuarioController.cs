using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Data.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarteiraDeJogos.Controllers;

[ApiController]
[Route("Usuarios")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuariosRepository _usuarioRepository;
    private ObjectResult httpResponse = new ObjectResult("");

    public UsuarioController(IUsuariosRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet]
    public ObjectResult ListarUsuarios()
    {
        List<ReadUsuariosDto> usuarios = _usuarioRepository.ListarUsuarios();
        httpResponse.StatusCode = 200;
        httpResponse.Value = usuarios;
        return httpResponse;
    }

    [HttpGet("{id}")]
    public ObjectResult BuscarUsuarioPorId(int id)
    {
        ReadUsuariosDto usuario = _usuarioRepository.BuscarUsuarioPorId(id);
        if (usuario == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Usuário não encontrado.";
            return httpResponse;
        }
        string json = JsonConvert.SerializeObject(usuario);
        httpResponse.StatusCode = 200;
        httpResponse.Value = json;
        return httpResponse;
    }
    [HttpPost]
    public ObjectResult CadastrarUsuario([FromBody] CreateUsuarioDto usuario)
    {
        ReadUsuariosDto usuarioNovo = _usuarioRepository.CadastrarUsuario(usuario);
        if (usuarioNovo == null)
        {
            httpResponse.StatusCode = 400;
            httpResponse.Value = "Erro ao cadastrar usuário.";
            return httpResponse;
        }
        string json = JsonConvert.SerializeObject(usuarioNovo);
        httpResponse.StatusCode = 201;
        httpResponse.Value = json;
        return httpResponse;
    }
    [Authorize]
    [HttpPut("{id}")]
    public ObjectResult AlterarUsuario(int id, [FromBody] UpdateUsuariosDto usuario)
    {
        ReadUsuariosDto usuarioNovo = _usuarioRepository.AtualizarUsuario(id, usuario);
        if (usuarioNovo == null)
        {
            httpResponse.StatusCode = 404;
            httpResponse.Value = "Usuário não encontrado.";
            return httpResponse;
        }
        string json = JsonConvert.SerializeObject(usuarioNovo);
        httpResponse.StatusCode = 200 ;
        httpResponse.Value = json;
        return httpResponse;
    }
    [Authorize]
    [HttpDelete("{id}")]
    public ObjectResult DeletarUsuario(int id)
    {
        bool usuarioNovo = _usuarioRepository.DeletarUsuario(id);
        if (usuarioNovo)
        {
            httpResponse.StatusCode = 204;
            httpResponse.Value = "Usuário excluido com sucesso.";
            return httpResponse;
        }
        httpResponse.StatusCode = 404;
        httpResponse.Value = "Usuário não encontrado.";
        return httpResponse;
    }
}