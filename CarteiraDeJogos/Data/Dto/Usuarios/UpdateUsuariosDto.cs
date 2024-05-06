namespace CarteiraDeJogos.Data.Dto.Usuarios;

public class UpdateUsuariosDto
{
    public UpdateUsuariosDto(string nome, List<int> jogos, List<int> jogosFavoritos)
    {
        Nome = nome;
        Jogos = jogos;
        JogosFavoritos = jogosFavoritos;
    }

    public string Nome { get; set; }

    public List<int> Jogos { get; set; }

    public List<int> JogosFavoritos { get; set; }
}
