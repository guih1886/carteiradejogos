using System.ComponentModel.DataAnnotations;

namespace CarteiraDeJogos.Data.Dto.Usuarios
{
    public class CreateUsuarioDto
    {
        public CreateUsuarioDto(string nome, string senha, string confirmacaoSenha)
        {
            Nome = nome;
            Senha = senha;
            ConfirmacaoSenha = confirmacaoSenha;
        }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        [Compare("Senha", ErrorMessage = "As senhas não são iguais.")]
        public string ConfirmacaoSenha { get; set; }
    }
}
