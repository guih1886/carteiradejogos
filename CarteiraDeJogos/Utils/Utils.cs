using CarteiraDeJogos.Data;
using CarteiraDeJogos.Models;

public static class Utils
{
    public static List<Usuario>? ListarUsuarios(JogosContext _context)
    {
        List<Usuario>? usuarioId = _context.Usuarios.ToList();
        return usuarioId;
    }

    public static void AdicionarJogoUsuario(int idUsuario, int idJogo, JogosContext _context)
    {
        Usuario? usuario =  _context.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
        usuario!.Jogos!.Add(idJogo);
        _context.SaveChanges();
    }
}
