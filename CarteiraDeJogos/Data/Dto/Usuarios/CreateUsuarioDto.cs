using System.ComponentModel.DataAnnotations;

namespace CarteiraDeJogos.Data.Dto.Usuarios
{
    public record CreateUsuarioDto
    {
        public CreateUsuarioDto(string nome, string email, string senha, string confirmacaoSenha)
        {
            Nome = nome;
            Email = email;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
        }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        [Compare("Senha", ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmacaoSenha { get; set; }
    }
}
