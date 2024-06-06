using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogos.Models;
using CarteiraDeJogosForms.Classes;
using CarteiraDeJogosForms.Classes.Interfaces;
using CarteiraDeJogosForms.Classes.Utils;
using CarteiraDeJogosForms.Forms.Cadastrar;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Security.Claims;

namespace CarteiraDeJogosForms.Forms
{
    public partial class Form_Login : Form
    {
        private IHttpClient _httpClient;
        private IConfiguration _configuration;
        public Form_Login()
        {
            _configuration = InstanciaIConfiguration.GetInstancia();
            _httpClient = new HttpClientBuilder(_configuration["UrlBase"]!, "");
            InitializeComponent();
        }

        private async void Btn_Entrar_Click(object sender, EventArgs e)
        {
            LoginUsuarioDto usuario = new LoginUsuarioDto(Txt_Email.Text, Txt_Senha.Text);
            HttpResponseMessage resposta = await _httpClient.PostRequisition("/Login", usuario);
            string msg = await resposta.Content.ReadAsStringAsync();
            if (!resposta.IsSuccessStatusCode)
            {
                Lbl_Erro.Text = msg;
                Txt_Email.Focus();
            }
            else
            {
                string jwt = msg;
                _httpClient = new HttpClientBuilder(_configuration["UrlBase"]!, jwt);
                ClaimsPrincipal dados = DeserizalizeJwt.JwtClaims(jwt, _configuration["Jwt:Key"]!)!;
                List<Claim> listaClaims = dados.Claims.ToList();
                int usuarioId = Int32.Parse(listaClaims[0].Value);
                Form_Principal form_Principal = new Form_Principal(_httpClient, this, usuarioId);
                form_Principal.Show();
                EsconderTela();
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
            EsconderTela();
        }

        private void EsconderTela()
        {
            Lbl_Erro.Text = "";
            Txt_Email.Text = "";
            Txt_Senha.Text = "";
            Txt_Email.Focus();
            this.Hide();
        }
    }
}
