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

    [NotNull]
    public string Email { get; set; }

    [NotNull]
    public string Senha { get; set; }
}