using CarteiraDeJogosForms.Classes;
using CarteiraDeJogosForms.Classes.Utils;
using CarteiraDeJogosForms.Forms.Jogos;
using CarteiraDeJogosForms.Forms.Usuario;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace CarteiraDeJogosForms.Forms
{
    public partial class Form_Principal : Form
    {
        private Form loginForm;
        private readonly string jwt;
        private string? url;
        private string usuarioEmail = "";
        private int usuarioId = 0;
        private HttpClientBuilder _httpClientBuilder;
        private IConfiguration _configuration;
        public DialogResult dialogResult;

        public Form_Principal(Form login, string jwt)
        {
            _configuration = InstanciaIConfiguration.GetInstancia();
            loginForm = login;
            this.jwt = jwt;
            ValidaDadosUsuario();
            _httpClientBuilder = new HttpClientBuilder(url!, jwt);
            InitializeComponent();
        }

        private void ValidaDadosUsuario()
        {
            string key = _configuration!["Jwt:Key"]!;
            string url = _configuration!["UrlBase"]!;
            ClaimsPrincipal dados = DeserizalizeJwt.JwtClaims(jwt, key)!;
            List<Claim> listaClaims = dados.Claims.ToList();
            usuarioId = Int32.Parse(listaClaims[0].Value);
            usuarioEmail = listaClaims[1].Value;
            this.url = url;
        }
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialogResult = DialogResult.Cancel;
            loginForm.Show();
            this.Close();
        }
        private void todosOsJogosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form todosOsJogos = new Form_TodosOsJogos(_httpClientBuilder, usuarioId);
            todosOsJogos.Show();
        }
        private void jogosFavoritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form jogosFavoritos = new Form_JogosFavoritos(_httpClientBuilder, usuarioId);
            jogosFavoritos.Show();
        }
        private void perfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form perfil = new Form_Perfil(_httpClientBuilder, usuarioId);
            perfil.ShowDialog();
        }
        private void cadastrarJogoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form cadastrarJogo = new Form_CadastroDeJogos(_httpClientBuilder, usuarioId);
            cadastrarJogo.Show();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Form cadastrarJogo = new Form_CadastroDeJogos(_httpClientBuilder, usuarioId);
            cadastrarJogo.Show();
        }
    }
}
