using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CarteiraDeJogos.Data.Dto.Usuarios;

public record LoginUsuarioDto
{
    public LoginUsuarioDto(string email, string senha)
    {
        Senha = senha;
        Email = email;
    }

    [Required(ErrorMessage = "E-mail não pode estar vazio.")]
    [NotNull]
    public string Email { get; set; }

    [Required(ErrorMessage = "A senha deve ser informada.")]
    [NotNull]
    public string Senha { get; set; }
}