using System.Text.Json.Serialization;

namespace CarteiraDeJogos.Data.Dto.Usuarios;

public record ReadUsuariosDto
{
    public ReadUsuariosDto(int id, string nome, List<int> jogos, List<int> jogosFavoritos)
    {
        Id = id;
        Nome = nome;
        Jogos = jogos;
        JogosFavoritos = jogosFavoritos;
    }

    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
    [JsonPropertyName("jogos")]
    public List<int> Jogos { get; set; }
    [JsonPropertyName("jogosFavoritos")]
    public List<int> JogosFavoritos { get; set; }
}
