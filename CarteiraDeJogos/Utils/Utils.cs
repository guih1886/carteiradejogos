using CarteiraDeJogos.Data;
using CarteiraDeJogos.Models;

public static class Utils
{
    public static Usuario? BuscarUsuario(int id, JogosContext _context)
    {
        Usuario? usuarioId = _context.Usuarios.FirstOrDefault(u => u.Id == id);
        return usuarioId;
    }

    public static Jogos? BuscarJogos(int id, JogosContext _context)
    {
        Jogos? jogo = _context.Jogos.FirstOrDefault(j => j.Id == id && j.Ativo == 1);
        return jogo;
    }

    public static void AdicionarJogoUsuario(int id, int idJogo, JogosContext _context)
    {
        Usuario? usuario = BuscarUsuario(id, _context);
        usuario!.Jogos!.Add(idJogo);
        _context.SaveChanges();
    }
}
