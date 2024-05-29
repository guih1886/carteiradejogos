﻿using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogosForms.Classes;
using CarteiraDeJogosForms.Forms.Cadastrar;
using System.Net;

namespace CarteiraDeJogosForms.Forms
{
    public partial class Form_Login : Form
    {
        private HttpClientBuilder _httpClient = new HttpClientBuilder();
        public Form_Login()
        {
            InitializeComponent();
        }

        private async void Btn_Entrar_Click(object sender, EventArgs e)
        {
            LoginUsuarioDto usuario = new LoginUsuarioDto(Txt_Email.Text, Txt_Senha.Text);
            var resposta = await _httpClient.PostReq("/Login", usuario);
            if (resposta.StatusCode != HttpStatusCode.OK)
            {
                Txt_Email.Text = "";
                Txt_Senha.Text = "";
                Txt_Email.Focus();
                Lbl_Erro.ForeColor = Color.Red;
                string msg = await resposta.Content.ReadAsStringAsync();
                Lbl_Erro.Text = msg;
            }
            else
            {
                string jwt = await resposta.Content.ReadAsStringAsync();
                File.WriteAllText("C:\\Windows\\Temp\\jwt.txt", jwt);
                Form_Principal form_Principal = new Form_Principal(this);
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
            if (File.Exists("C:\\Windows\\Temp\\jwt.txt"))
            {
                File.Delete("C:\\Windows\\Temp\\jwt.txt");
            }
            this.Close();
        }
        private void Btn_Cadastrar_Click(object sender, EventArgs e)
        {
            Form_Cadastrar form_cadastrar = new Form_Cadastrar(this);
            form_cadastrar.Show();
            Lbl_Erro.Text = "";
            Txt_Email.Text = "";
            Txt_Senha.Text = "";
            Txt_Email.Focus();
            this.Hide();
        }
    }
}