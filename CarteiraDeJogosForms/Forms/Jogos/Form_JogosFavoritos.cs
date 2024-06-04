using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogosForms.Classes;
using Newtonsoft.Json;

namespace CarteiraDeJogosForms.Forms.Jogos;

public partial class Form_JogosFavoritos : Form
{
    private int usuarioId;
    private string usuarioEmail;
    private HttpClientBuilder _httpClientBuilder;
    public Form_JogosFavoritos(HttpClientBuilder httpCliente, int usuarioId, string usuarioEmail)
    {
        _httpClientBuilder = httpCliente;
        this.usuarioId = usuarioId;
        this.usuarioEmail = usuarioEmail;
        PreencherListaDeJogosDoUsuario();
        InitializeComponent();
    }
    private async void PreencherListaDeJogosDoUsuario()
    {
        HttpResponseMessage resposta = await _httpClientBuilder.GetJogosFavoritosDoUsuario(usuarioId);

        List<int> listaDeJogos = JsonConvert.DeserializeObject<List<int>>(await resposta.Content.ReadAsStringAsync())!;
        if (listaDeJogos.Count == 0)
        {
            Dgv_JogosFavoritos.DataSource = null;
            Lbl_Total.Text = "Nenhum jogo marcado como favorito.";
        }
        else
        {
            List<ReadJogosDto> jogos = new List<ReadJogosDto>();
            foreach (var item in listaDeJogos)
            {
                HttpResponseMessage respostaJogo = await _httpClientBuilder.GetJogo(item);
                if (respostaJogo.IsSuccessStatusCode)
                {
                    ReadJogosDto jogo = JsonConvert.DeserializeObject<ReadJogosDto>(await respostaJogo.Content.ReadAsStringAsync())!;
                    jogos.Add(jogo);
                }
            }
            Dgv_JogosFavoritos.DataSource = jogos;
            Lbl_Total.Text = $"{jogos.Count} jogos marcados como favorito.";
            if (jogos.Count == 1) Lbl_Total.Text = $"{jogos.Count} jogos marcados como favorito.";
        }
    }
}
