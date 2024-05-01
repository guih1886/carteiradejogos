using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarteiraDeJogos.Models;

public class Usuario
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome não pode estar vazio.")]
    [MinLength(5, ErrorMessage = "Nome inválido.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A senha não pode estar vazia.")]
    [MinLength(3, ErrorMessage = "Senha inválida.")]
    public string Senha { get; set; }

    public List<int>? Jogos { get; set; }

    public List<int>? JogosFavoritos { get; set; }
}
