using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogosForms.Classes.Interfaces;
using CarteiraDeJogosForms.Classes.Utils;

namespace CarteiraDeJogosForms.Forms.Jogos
{
    public partial class Form_TodosOsJogos : Form
    {
        private IHttpClient _httpClientBuilder;
        private int usuarioId;
        public Form_TodosOsJogos(IHttpClient httpClient, int usuarioId)
        {
            _httpClientBuilder = httpClient;
            this.usuarioId = usuarioId;
            InitializeComponent();
            PreencherListaDeJogosDoUsuario();
        }

        private async void PreencherListaDeJogosDoUsuario()
        {
            List<ReadJogosDto> listaDeJogos = await BuscarJogosDoUsuario.BuscarJogos($"/JogosDoUsuario/{usuarioId}/todosJogos", _httpClientBuilder);
            if (listaDeJogos.Count == 0)
            {
                Dgv_Jogos.DataSource = null;
                Lbl_Total.Text = "Nenhum jogo cadastrado";
            }
            else
            {
                Dgv_Jogos.DataSource = listaDeJogos;
                Lbl_Total.Text = $"{listaDeJogos.Count} jogo(s) cadastrado(s).";
            }
        }
    }
}
