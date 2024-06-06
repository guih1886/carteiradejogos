using System.Text.RegularExpressions;

namespace CarteiraDeJogosForms.Classes.Utils
{
    public static class Validacoes
    {
        public static async Task<string> ValidaCadastrarUsuario(HttpResponseMessage resposta)
        {
            string msg = await resposta.Content.ReadAsStringAsync();
            if (msg.Contains("O nome deve ser preenchido.")) return "Erro: Preencha o nome.";
            if (msg.Contains("O e-mail deve ser preenchido.")) return "Erro: Preencha o e-mail.";
            if (msg.Contains("E-mail já cadastrado.")) return "Erro: E-mail já cadastrado.";
            if (msg.Contains("E-mail inválido.")) return "Erro: E-mail inválido.";
            if (msg.Contains("A senha deve ser preenchida.")) return "Erro: Preencha a senha.";
            if (msg.Contains("A confirmação de senha deve ser preenchida.")) return "Erro: Preencha a confirmação da senha.";
            if (msg.Contains("As senhas não são iguais.")) return "Erro: As senhas não são iguais.";
            return "Ok";
        }
        public static async Task<string> ValidaCadastrarEAlterarJogo(HttpResponseMessage resposta)
        {
            string msg = await resposta.Content.ReadAsStringAsync();
            if (msg.Contains("O nome não pode ser vazio.")) return "Erro: O nome não pode ser vazio.";
            if (msg.Contains("Nome muito curto.")) return "Erro: Nome muito curto.";
            if (msg.Contains("A descrição não pode ser vazia.")) return "Erro: A descrição não pode ser vazia.";
            if (msg.Contains("Descrição muito curta, insira mais informações.")) return "Erro: Descrição muito curta, insira mais informações.";
            if (msg.Contains("A imagem não pode ser vazio.")) return "Erro: A imagem não pode ser vazio.";
            if (msg.Contains("A url da imagem é inválida.")) return "Erro: A url da imagem é inválida.";
            return "Ok";
        }
        public static bool ValidaEmail(string email)
        {
            string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
        }
    }
}
