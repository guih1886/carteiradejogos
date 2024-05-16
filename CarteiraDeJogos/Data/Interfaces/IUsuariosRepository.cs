using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;

namespace CarteiraDeJogos.Data.Interfaces;

public interface IUsuariosRepository
{
    Usuario? BuscarUsuario(int id);
    ReadUsuariosDto BuscarUsuarioPorId(int id);
    List<ReadUsuariosDto> ListarUsuarios();
    ReadUsuariosDto CadastrarUsuario(CreateUsuarioDto usuarioDto);
    ReadUsuariosDto AtualizarUsuario(int id, UpdateUsuariosDto usuarioDto);
    bool DeletarUsuario(int id);
    string AdicionarJogoUsuario(int usuarioId, int id);
    string AdicionarJogoFavorito(int usuarioId, int idJogoFavorito);
    string RemoverJogo(int usuarioId, int idJogo);
    string RemoverJogoFavorito(int usuarioId, int idJogo);
    Usuario? BuscarUsuarioEmail(string email);
}
