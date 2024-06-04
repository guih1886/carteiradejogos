using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Models;
using CarteiraDeJogosForms.Classes;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace CarteiraDeJogosForms.Forms.Jogos;

public partial class Form_BuscarJogo : Form
{
    private List<ReadJogosDto>? todosOsJogos;
    private List<ReadJogosDto>? todosOsJogosAux;
    private int usuarioId;
    private HttpClientBuilder _httpClientBuilder;
    public int jogoId { get; set; }

    public Form_BuscarJogo(HttpClientBuilder httpClientBuilder, int usuarioId, List<ReadJogosDto> todosOsJogos)
    {
        this.usuarioId = usuarioId;
        this.todosOsJogos = todosOsJogos;
        _httpClientBuilder = httpClientBuilder;
        InitializeComponent();
        Cmb_Genero.Items.Add("");
        foreach (var genero in Enum.GetValues(typeof(Genero)))
        {
            Cmb_Genero.Items.Add(genero);
        }
        Cmb_Genero.SelectedIndex = 0;
        Cmb_Ativo.SelectedIndex = 0;
        Dgv_Jogos.DataSource = todosOsJogos.Where(j => j.Ativo == 1).ToList();
        Txt_Nome.Focus();
    }

    private void Btn_Cancelar_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        this.Close();
    }
    private void Btn_Selecionar_Click(object sender, EventArgs e)
    {
        DataGridViewRow jogoSelecionado = Dgv_Jogos.SelectedRows[0];
        jogoId = Int32.Parse(jogoSelecionado.Cells[0].Value.ToString()!);
        DialogResult = DialogResult.OK;
        this.Close();
    }

    private void Btn_Buscar_Click(object sender, EventArgs e)
    {
        List<ReadJogosDto> novaLista = new List<ReadJogosDto>();
        int ativo = ValidaStatusAtivo();
        string nome = Txt_Nome.Text;
        string plataforma = Txt_Plataforma.Text;
        int id = 0;
        if (!Txt_Id.Text.IsNullOrEmpty()) id = Int32.Parse(Txt_Id.Text);
        if (id == 0)
        {
            if (Cmb_Genero.SelectedIndex == 0)
            {
                novaLista = todosOsJogos!.Where(j => j.Ativo == ativo && j.Nome.Contains(nome) && j.Plataforma.Contains(plataforma)).ToList();
            }
            else
            {
                Genero genero = (Genero)Cmb_Genero.SelectedItem!;
                novaLista = todosOsJogos!.Where(j => j.Ativo == ativo && j.Nome.Contains(nome) && j.Plataforma.Contains(plataforma) && j.Genero == genero.ToString()).ToList();
            }
            Dgv_Jogos.DataSource = novaLista.OrderBy(j => j.Id).ToList();
        }
        else
        {
            novaLista = todosOsJogos!.Where(j => j.Id == id && j.Ativo == ativo).ToList();
            Dgv_Jogos.DataSource = novaLista.OrderBy(j => j.Id).ToList();
        }
    }

    private int ValidaStatusAtivo()
    {
        int retorno = 0;
        if (Cmb_Ativo.SelectedIndex == 0)
        {
            retorno = 1;
        }
        if (Cmb_Ativo.SelectedIndex == 1)
        {
            retorno = 0;
        }
        return retorno;
    }
    private void Btn_Limpar_Click(object sender, EventArgs e)
    {
        Txt_Id.Text = string.Empty;
        Txt_Nome.Text = string.Empty;
        Txt_Plataforma.Text = string.Empty;
        Cmb_Genero.SelectedIndex = 0;
        Cmb_Ativo.SelectedIndex = 0;
    }

    private async void Ckb_Favoritos_CheckedChanged(object sender, EventArgs e)
    {
        int ativo = ValidaStatusAtivo();
        if (Ckb_Favoritos.CheckState == CheckState.Checked)
        {
            HttpResponseMessage resposta = await _httpClientBuilder.GetJogosFavoritosDoUsuario(usuarioId);
            List<int> todosOsJogosFavoritos = JsonConvert.DeserializeObject<List<int>>(await resposta.Content.ReadAsStringAsync())!;
            List<ReadJogosDto> todosOsJogosFavoritosRead = new List<ReadJogosDto>();
            foreach (var item in todosOsJogosFavoritos)
            {
                HttpResponseMessage response = await _httpClientBuilder.GetJogo(item);
                if (resposta.IsSuccessStatusCode)
                {
                    var jogo = JsonConvert.DeserializeObject<ReadJogosDto>(await response.Content.ReadAsStringAsync());
                    todosOsJogosFavoritosRead.Add(jogo!);
                }
            }
            todosOsJogosAux = todosOsJogos;
            todosOsJogos = todosOsJogosFavoritosRead;
            Dgv_Jogos.DataSource = todosOsJogosFavoritosRead.Where(j => j.Ativo == ativo).OrderBy(j => j.Id).ToList();
        }
        if (Ckb_Favoritos.CheckState == CheckState.Unchecked)
        {
            todosOsJogos = todosOsJogosAux!.OrderBy(j => j.Id).ToList();
            Dgv_Jogos.DataSource = todosOsJogos.Where(j => j.Ativo == ativo).OrderBy(j => j.Id).ToList();
        }
    }
}
