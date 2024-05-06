using CarteiraDeJogos.Models;
using System.ComponentModel.DataAnnotations;

namespace CarteiraDeJogos.Data.Dto.Jogos;

public class ReadJogosDto
{

    public string Nome { get; set; }

    public string EnderecoImagem { get; set; }

    public string Descricao { get; set; }

    public string Genero { get; set; }

    public string AnoLancamento { get; set; }

    public string Plataforma { get; set; }

    public int Nota { get; set; }
}
