using System.ComponentModel.DataAnnotations;

namespace CarteiraDeJogos.Models;

public class Usuario
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O e-mail não pode estar vazio.")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "O nome não pode estar vazio.")]
    [MinLength(5, ErrorMessage = "Nome inválido.")]
    public required string Nome { get; set; }

    [Required(ErrorMessage = "A senha não pode estar vazia.")]
    [MinLength(3, ErrorMessage = "Senha inválida.")]
    [DataType(DataType.Password)]
    public required string Senha { get; set; }

    public List<int>? Jogos { get; set; }

    public List<int>? JogosFavoritos { get; set; }
}
