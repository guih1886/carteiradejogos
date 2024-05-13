using CarteiraDeJogos.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CarteiraDeJogos.Data.Dto.Jogos;

public class ReadJogosDto
{
    public ReadJogosDto(int id, string nome, string enderecoImagem, string descricao, string genero, string anoLancamento, string plataforma, int nota, int ativo)
    {
        Id = id;
        Nome = nome;
        EnderecoImagem = enderecoImagem;
        Descricao = descricao;
        Genero = genero;
        AnoLancamento = anoLancamento;
        Plataforma = plataforma;
        Nota = nota;
        Ativo = ativo;
    }
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("nome")]
    public string Nome { get; set; }
    [JsonPropertyName("enderecoImagem")]
    public string EnderecoImagem { get; set; }
    [JsonPropertyName("descricao")]
    public string Descricao { get; set; }
    [JsonPropertyName("genero")]
    public string Genero { get; set; }
    [JsonPropertyName("anoLancamento")]
    public string AnoLancamento { get; set; }
    [JsonPropertyName("plataforma")]
    public string Plataforma { get; set; }
    [JsonPropertyName("ativo")]
    public int Ativo { get; set; }

    [JsonPropertyName("nota")]
    public int Nota { get; set; }


    public override string ToString()
    {
        return $"""
            Id == {Id}
            Nome == {Nome} 
            EnderecoImagem == {EnderecoImagem}
            Descricao == {Descricao}
            Genero == {Genero}
            AnoLancamento == {AnoLancamento}
            Plataforma =={Plataforma}
            Ativo == {Ativo}
            Nota == {Nota};
            """;
    }
}
