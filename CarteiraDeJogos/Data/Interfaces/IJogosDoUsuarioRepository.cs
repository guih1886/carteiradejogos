namespace CarteiraDeJogos.Data.Interfaces;

public interface IJogosDoUsuarioRepository
{
    string ListarTodosOsJogos(int usuarioId);
    string ListarJogosFavoritos(int usuarioId);
    string AdicionarJogoAoFavoritoDoUsuario(int usuarioId, int idJogoFavorito);
    string? RemoverJogoDoUsuario(int usuarioId, int idJogo);
    string? RemoverJogoFavoritoDoUsuario(int usuarioId, int idJogoFavorito);
}
