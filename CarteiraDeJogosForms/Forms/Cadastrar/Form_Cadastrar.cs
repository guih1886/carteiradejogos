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
            CreateUsuarioDto usuario = new CreateUsuarioDto(Txt_Nome.Text, Txt_Email.Text, Txt_Senha.Text, Txt_ConfirmaSenha.Text);
            HttpResponseMessage resposta = await _httpClientBuilder.PostReq("/Usuarios", usuario);
            string msg = await ValidaRequisicao.CadastrarUsuario(resposta);
            if (msg.Contains("Ok"))
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
