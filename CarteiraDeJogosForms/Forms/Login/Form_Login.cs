using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogosForms.Classes;
using CarteiraDeJogosForms.Classes.Interfaces;
using CarteiraDeJogosForms.Classes.Utils;
using CarteiraDeJogosForms.Forms.Cadastrar;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace CarteiraDeJogosForms.Forms
{
    public partial class Form_Login : Form
    {
        private IHttpClient _httpClient;
        private IConfiguration _configuration;
        public Form_Login()
        {
            _configuration = InstanciaIConfiguration.GetInstancia();
            string url = _configuration["UrlBase"]!;
            string jwt = _configuration["Jwt:Key"]!;
            _httpClient = new HttpClientBuilder(url, jwt);
            InitializeComponent();
        }

        private async void Btn_Entrar_Click(object sender, EventArgs e)
        {
            LoginUsuarioDto usuario = new LoginUsuarioDto(Txt_Email.Text, Txt_Senha.Text);
            var resposta = await _httpClient.PostRequisition("/Login", usuario);
            if (resposta.StatusCode != HttpStatusCode.OK)
            {
                Txt_Email.Focus();
                string msg = await resposta.Content.ReadAsStringAsync();
                Lbl_Erro.Text = msg;
            }
            else
            {
                string jwt = await resposta.Content.ReadAsStringAsync();
                Form_Principal form_Principal = new Form_Principal(this, jwt);
                form_Principal.Show();
                Lbl_Erro.Text = "";
                Txt_Email.Text = "";
                Txt_Senha.Text = "";
                Txt_Email.Focus();
                this.Hide();
            }
        }
        private void Btn_Sair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_Cadastrar_Click(object sender, EventArgs e)
        {
            Form_Cadastrar form_cadastrar = new Form_Cadastrar(_httpClient, this);
            form_cadastrar.Show();
            Lbl_Erro.Text = "";
            Txt_Email.Text = "";
            Txt_Senha.Text = "";
            Txt_Email.Focus();
            this.Hide();
        }
    }
}
