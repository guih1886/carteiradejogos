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

        [Required(ErrorMessage = "O nome deve ser preenchido.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        [Required(ErrorMessage = "O e-mail deve ser preenchido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha deve ser preenchida.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "A confirmação de senha deve ser preenchida.")]
        [Compare("Senha", ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmacaoSenha { get; set; }
    }
}
