using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CarteiraDeJogos.Models;

public class Jogos
{
    public Jogos(string enderecoImagem, string nome, string descricao)
    {
        EnderecoImagem = enderecoImagem;
        Nome = nome;
        Descricao = descricao;
    }

    [Key]
    [Required]
    public int Id { get; set; }

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

    [AllowNull]
    public string AnoLancamento { get; set; }

    [AllowNull]
    public string Plataforma { get; set; }

    [AllowNull]
    public int Nota { get; set; }

    [Required(ErrorMessage = "O id do usuário deve ser preenchido.")]
    public int UsuarioId { get; set; }

    public int Ativo { get; set; }

    [ForeignKey("UsuarioId")]
    public virtual required Usuario Usuario { get; set; }
}
