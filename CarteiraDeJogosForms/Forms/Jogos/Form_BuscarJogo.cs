using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogosForms.Classes;
using Newtonsoft.Json;

namespace CarteiraDeJogosForms.Forms.Jogos;

public partial class Form_BuscarJogo : Form
{
    private List<ReadJogosDto>? todosOsJogos;
    private int usuarioId;
    private HttpClientBuilder _httpClientBuilder;
    public int jogoId { get; set; }

    public Form_BuscarJogo(HttpClientBuilder httpClientBuilder, int usuarioId, List<ReadJogosDto> todosOsJogos)
    {
        this.usuarioId = usuarioId;
        this.todosOsJogos = todosOsJogos;
        _httpClientBuilder = httpClientBuilder;
        InitializeComponent();
        Dgv_Jogos.DataSource = todosOsJogos;
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
}
