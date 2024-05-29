using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogosForms.Classes;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;

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
            string json = JsonConvert.SerializeObject(usuario);
            var content = new StringContent(json, Encoding.UTF8, new MediaTypeHeaderValue("application/json"));
            var resposta = await _httpClient.PostReq("/Login", content);
            if (resposta.StatusCode != HttpStatusCode.OK)
            {
                Txt_Email.Text = "";
                Txt_Senha.Text = "";
                Txt_Email.Focus();
                Lbl_Erro.ForeColor = Color.Red;
                Lbl_Erro.Text = await resposta.Content.ReadAsStringAsync();
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
    }
}
