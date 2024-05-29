using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogosForms.Classes;
using CarteiraDeJogosForms.Classes.Utils;

namespace CarteiraDeJogosForms.Forms.Cadastrar
{
    public partial class Form_Cadastrar : Form
    {
        private Form loginForm;
        private HttpClientBuilder _httpClientBuilder = new HttpClientBuilder();
        public Form_Cadastrar(Form login)
        {
            InitializeComponent();
            loginForm = login;
        }

        private void Btn_Voltar_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Close();
        }
        private async void Btn_Cadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Txt_Nome.Text) || string.IsNullOrEmpty(Txt_Email.Text) || string.IsNullOrEmpty(Txt_Senha.Text) || string.IsNullOrEmpty(Txt_ConfirmaSenha.Text))
            {
                Lbl_Erro.Text = "Preencha todos os campos.";
            }
            else if (!ValidaEmail.ValidarEmail(Txt_Email.Text))
            {
                Lbl_Erro.Text = "E-mail inválido.";
            }
            else if (Txt_Senha.Text != Txt_ConfirmaSenha.Text)
            {
                Lbl_Erro.Text = "As senhas não são iguais.";
            }
            else
            {
                CreateUsuarioDto usuario = new CreateUsuarioDto(Txt_Nome.Text, Txt_Email.Text, Txt_Senha.Text, Txt_ConfirmaSenha.Text);
                HttpResponseMessage resposta = await _httpClientBuilder.PostReq("/Usuarios", usuario);
                string msg = await resposta.Content.ReadAsStringAsync();
                if (msg.Contains(Txt_Nome.Text))
                {
                    Lbl_Erro.Text = "";
                    MessageBox.Show("Usuário cadastrado com sucesso", "Cadastro de Usuários", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loginForm.Show();
                    this.Close();
                }
                else
                {
                    Lbl_Erro.Text = msg;
                }
            }
        }

    }
}
