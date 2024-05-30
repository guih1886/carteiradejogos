using CarteiraDeJogosForms.Classes;
using CarteiraDeJogosForms.Forms.Jogos;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace CarteiraDeJogosForms.Forms
{
    public partial class Form_Principal : Form
    {
        private Form loginForm;
        private string jwt;
        private int usuarioId = 0;
        private string usuarioEmail = "";
        private HttpClientBuilder _httpClientBuilder = new HttpClientBuilder();
        private IConfiguration? _configuration;

        public Form_Principal(Form login, string jwt)
        {
            InstanciaIConfiguration();
            loginForm = login;
            this.jwt = jwt;
            ValidaDadosUsuario();
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            this.Close();
        }
        private void todosOsJogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form todosOsJogos = new Form_TodosOsJogos(_httpClientBuilder, usuarioId, usuarioEmail);
            todosOsJogos.ShowDialog();
        }
        private void jogosFavoritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form jogosFavoritos = new Form_JogosFavoritos();
            jogosFavoritos.ShowDialog();
        }


        private void InstanciaIConfiguration()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            _configuration = builder.Build();
        }
        private void ValidaDadosUsuario()
        {
            string key = _configuration!["Jwt:Key"]!;
            ClaimsPrincipal dados = DeserizalizeJwt.JwtClaims(jwt, key)!;
            List<Claim> listaClaims = dados.Claims.ToList();
            usuarioId = Int32.Parse(listaClaims[0].Value);
            usuarioEmail = listaClaims[1].Value;
        }
    }
}
