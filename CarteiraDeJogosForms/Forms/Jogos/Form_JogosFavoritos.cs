using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogosForms.Classes.Interfaces;
using CarteiraDeJogosForms.Classes.Utils;

namespace CarteiraDeJogosForms.Forms.Jogos;

public partial class Form_JogosFavoritos : Form
{
    private IHttpClient _httpClientBuilder;
    private int usuarioId;
    public Form_JogosFavoritos(IHttpClient httpClient, int usuarioId)
    {
        _httpClientBuilder = httpClient;
        this.usuarioId = usuarioId;
        InitializeComponent();
        PreencherListaDeJogosDoUsuario();
    }

    private async void PreencherListaDeJogosDoUsuario()
    {
        List<ReadJogosDto> listaDeJogos = await BuscarJogosDoUsuario.ConverterListaDeJogos($"/JogosDoUsuario/{usuarioId}/jogosfavoritos", _httpClientBuilder);
        if (listaDeJogos.Count == 0)
        {
            Dgv_JogosFavoritos.DataSource = null;
            Lbl_Total.Text = "Nenhum jogo marcado como favorito.";
        }
        else
        {
            Dgv_JogosFavoritos.DataSource = listaDeJogos;
            Lbl_Total.Text = $"{listaDeJogos.Count} jogo(s) marcado(s) como favorito.";
        }
    }
}
