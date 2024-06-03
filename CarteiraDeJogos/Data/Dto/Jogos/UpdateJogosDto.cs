using CarteiraDeJogos.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarteiraDeJogos.Data.Dto.Jogos;

public class UpdateJogosDto
{
    public UpdateJogosDto(string enderecoImagem, string nome, string descricao, Genero genero, string anoLancamento, string plataforma, int nota)
    {
        Nome = nome;
        EnderecoImagem = enderecoImagem;
        Descricao = descricao;
        Genero = genero;
        AnoLancamento = anoLancamento;
        Plataforma = plataforma;
        Nota = nota;
    }

    [Required(ErrorMessage = "A imagem não pode ser vazio.")]
    [RegularExpression("^(https?:\\/\\/)?.*$", ErrorMessage = "A url da imagem é inválida.")]
    [JsonPropertyName("enderecoImagem")]
    public string EnderecoImagem { get; set; }

    [Required(ErrorMessage = "O nome não pode ser vazio.")]
    [MinLength(3, ErrorMessage = "Nome muito curto.")]
    [JsonPropertyName("nome")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A descrição não pode ser vazia.")]
    [MinLength(20, ErrorMessage = "Descrição muito curta, insira mais informações.")]
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O Genero não pode ser vazio.")]
    [JsonPropertyName("genero")]
    public Genero Genero { get; set; }
    [JsonPropertyName("anoLancamento")]
    public string AnoLancamento { get; set; }
    [JsonPropertyName("plataforma")]
    public string Plataforma { get; set; }
    [JsonPropertyName("nota")]
    [RegularExpression("^(10|[0-9])$", ErrorMessage = "Nota deve ser de 0 a 10.")]
    public int Nota { get; set; }
}
