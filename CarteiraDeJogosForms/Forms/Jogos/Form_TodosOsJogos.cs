using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogosForms.Classes;
using Newtonsoft.Json;

namespace CarteiraDeJogosForms.Forms.Jogos
{
    public partial class Form_TodosOsJogos : Form
    {
        private int usuarioId;
        private string usuarioEmail;
        private HttpClientBuilder _httpClientBuilder;
        public Form_TodosOsJogos(HttpClientBuilder httpCliente, int usuarioId, string usuarioEmail)
        {
            _httpClientBuilder = httpCliente;
            this.usuarioId = usuarioId;
            this.usuarioEmail = usuarioEmail;
            PreencherListaDeJogosDoUsuario();
            InitializeComponent();
        }

        private async void PreencherListaDeJogosDoUsuario()
        {
            HttpResponseMessage resposta = await _httpClientBuilder.GetJogosDoUsuario(usuarioId);

            List<int> listaDeJogos = JsonConvert.DeserializeObject<List<int>>(await resposta.Content.ReadAsStringAsync())!;
            if (listaDeJogos.Count == 0)
            {
                Dgv_Jogos.DataSource = null;
            }
            else
            {
                List<ReadJogosDto> jogos = new List<ReadJogosDto>();
                foreach (var item in listaDeJogos)
                {
                    HttpResponseMessage respostaJogo = await _httpClientBuilder.GetJogo(item);
                    ReadJogosDto jogo = JsonConvert.DeserializeObject<ReadJogosDto>(await respostaJogo.Content.ReadAsStringAsync())!;
                    jogos.Add(jogo);
                }
                Dgv_Jogos.DataSource = jogos;
            }
        }
    }
}
