﻿using CarteiraDeJogos.Models;
using System.ComponentModel.DataAnnotations;

namespace CarteiraDeJogos.Data.Dto.Jogos;

public class CreateJogosDto
{
    [Required(ErrorMessage = "A imagem não pode ser vazio.")]
    public string EnderecoImagem { get; set; }

    [Required(ErrorMessage = "O nome não pode ser vazio.")]
    [MinLength(3, ErrorMessage = "Nome muito curto.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A descrição não pode ser vazia.")]
    [MinLength(20, ErrorMessage = "Descrição muito curta, insira mais informações.")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O Genero não pode ser vazio.")]
    public Genero Genero { get; set; }

    [Required(ErrorMessage = "O id do usuário não pode ser vazio.")]
    public int UsuarioId { get; set; }

    public string AnoLancamento { get; set; }

    public string Plataforma { get; set; }

    [RegularExpression("([10]|[1-9])", ErrorMessage = "Nota deve ser de 0 a 10.")]
    public int Nota { get; set; }
}
