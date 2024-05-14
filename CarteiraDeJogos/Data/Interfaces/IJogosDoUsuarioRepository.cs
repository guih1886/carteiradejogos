namespace CarteiraDeJogos.Data.Interfaces;

public interface IJogosDoUsuarioRepository
{
    List<int> ListarTodosOsJogos(int usuarioId);
    List<int> ListarJogosFavoritos(int usuarioId);
    List<int> AdicionarJogoAoFavoritoDoUsuario(int usuarioId, int idJogoFavorito);
    void RemoverJogoDoUsuario(int usuarioId, int idJogo);
    void RemoverJogoFavoritoDoUsuario(int usuarioId, int idJogoFavorito);
}
