using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;

namespace CarteiraDeJogos.Data.Interfaces;

public interface IUsuariosRepository
{
    Usuario? BuscarUsuario(int id);
    ReadUsuariosDto BuscarUsuarioPorId(int id);
    Usuario? BuscarUsuarioEmail(string email);
    List<ReadUsuariosDto> ListarUsuarios();
    List<int>? ListarTodosOsJogos(int usuarioId);
    List<int>? ListarJogosFavoritos(int usuarioId);
    ReadUsuariosDto CadastrarUsuario(CreateUsuarioDto usuarioDto);
    ReadUsuariosDto AtualizarUsuario(int id, UpdateUsuariosDto usuarioDto);
    bool DeletarUsuario(int id);
    List<int> AdicionarJogoUsuario(int usuarioId, int id);
    bool RemoverJogo(int usuarioId, int idJogo);
    List<int> AdicionarJogoFavorito(int usuarioId, int idJogoFavorito);
    bool RemoverJogoFavorito(int usuarioId, int idJogo);
}
