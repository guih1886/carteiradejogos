using CarteiraDeJogos.Models;
using System.ComponentModel.DataAnnotations;

namespace CarteiraDeJogos.Data.Dto.Jogos;

public class ReadJogosDto
{
    public ReadJogosDto(string nome, string enderecoImagem, string descricao, string genero, string anoLancamento, string plataforma, int nota)
    {
        Nome = nome;
        EnderecoImagem = enderecoImagem;
        Descricao = descricao;
        Genero = genero;
        AnoLancamento = anoLancamento;
        Plataforma = plataforma;
        Nota = nota;
    }

    public string Nome { get; set; }

    public string EnderecoImagem { get; set; }

    public string Descricao { get; set; }

    public string Genero { get; set; }

    public string AnoLancamento { get; set; }

    public string Plataforma { get; set; }

    public int Nota { get; set; }
}
