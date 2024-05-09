using CarteiraDeJogos.Data.Dto.Usuarios;

namespace CarteiraDeJogos.Data.Interfaces;

public interface IUsuariosRepository
{
    List<ReadUsuariosDto> ListarUsuarios();
    ReadUsuariosDto BuscarUsuarioPorId(int id);
    ReadUsuariosDto CadastrarUsuario(CreateUsuarioDto usuarioDto);
    ReadUsuariosDto AtualizarUsuario(int id, UpdateUsuariosDto usuarioDto);
    bool DeletarUsuario(int id);
}
