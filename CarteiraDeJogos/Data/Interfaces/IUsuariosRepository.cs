using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;

namespace CarteiraDeJogos.Data.Interfaces;

public interface IUsuariosRepository
{
    List<ReadUsuariosDto> ListarUsuarios();
    ReadUsuariosDto BuscarUsuarioPorId(int id);
    ReadUsuariosDto CadastrarUsuario(CreateUsuarioDto usuarioDto);
    ReadUsuariosDto AtualizarUsuario(int id, UpdateUsuariosDto usuarioDto);
    bool DeletarUsuario(int id);
}
