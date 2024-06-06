using CarteiraDeJogosForms.Classes.Interfaces;
using CarteiraDeJogosForms.Forms.Jogos;
using CarteiraDeJogosForms.Forms.Usuario;

namespace CarteiraDeJogosForms.Forms
{
    public partial class Form_Principal : Form
    {
        private IHttpClient _httpClientBuilder;
        private Form loginForm;
        private int usuarioId;

        public Form_Principal(IHttpClient httpClient, Form login, int usuarioId)
        {
            _httpClientBuilder = httpClient;
            loginForm = login;
            this.usuarioId = usuarioId;
            InitializeComponent();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
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
    }
}
