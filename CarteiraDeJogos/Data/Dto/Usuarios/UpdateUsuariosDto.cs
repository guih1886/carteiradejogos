using System.Text.Json.Serialization;

namespace CarteiraDeJogos.Data.Dto.Usuarios;

public record UpdateUsuariosDto
{
    public UpdateUsuariosDto(string nome, List<int> jogos, List<int> jogosFavoritos)
    {
        Nome = nome;
        Jogos = jogos;
        JogosFavoritos = jogosFavoritos;
    }

    [JsonPropertyName("nome")]
    public string Nome { get; set; }

    [JsonPropertyName("jogos")]
    public List<int> Jogos { get; set; }

    [JsonPropertyName("jogosFavoritos")]
    public List<int> JogosFavoritos { get; set; }
}
