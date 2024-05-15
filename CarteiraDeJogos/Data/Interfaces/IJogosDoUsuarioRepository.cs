namespace CarteiraDeJogos.Data.Interfaces;

public interface IJogosDoUsuarioRepository
{
    HttpResponseMessage ListarTodosOsJogos(int usuarioId);
    HttpResponseMessage ListarJogosFavoritos(int usuarioId);
    HttpResponseMessage AdicionarJogoAoFavoritoDoUsuario(int usuarioId, int idJogoFavorito);
    HttpResponseMessage RemoverJogoDoUsuario(int usuarioId, int idJogo);
    HttpResponseMessage RemoverJogoFavoritoDoUsuario(int usuarioId, int idJogoFavorito);
}
