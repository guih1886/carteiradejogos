namespace CarteiraDeJogos.Data.Interfaces;

public interface IJogosDoUsuarioRepository
{
    List<int> ListarTodosOsJogos(int usuarioId);
    List<int> ListarJogosFavoritos(int usuarioId);
    List<int> AdicionarJogoAoFavoritoDoUsuario(int usuarioId, int idJogoFavorito);
    List<int> RemoverJogoDoUsuario(int usuarioId, int idJogo);
    List<int> RemoverJogoFavoritoDoUsuario(int usuarioId, int idJogoFavorito);
}
