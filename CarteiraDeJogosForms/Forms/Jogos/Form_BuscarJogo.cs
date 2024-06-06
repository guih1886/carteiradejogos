using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Models;
using Microsoft.IdentityModel.Tokens;

namespace CarteiraDeJogosForms.Forms.Jogos;

public partial class Form_BuscarJogo : Form
{
    public int jogoId { get; set; }
    private List<ReadJogosDto> todosOsJogos;
    private List<ReadJogosDto>? todosOsJogosAux;
    private List<ReadJogosDto> jogosFavoritos;

    public Form_BuscarJogo(List<ReadJogosDto> todosOsJogos, List<ReadJogosDto> jogosFavoritos)
    {
        this.todosOsJogos = todosOsJogos;
        this.jogosFavoritos = jogosFavoritos;
        InitializeComponent();
        PreencherComboBoxGenero();
        PreencheDataGridJogos();
        Cmb_Ativo.SelectedIndex = 0;
    }

    private void Btn_Limpar_Click(object sender, EventArgs e)
    {
        Txt_Id.Text = string.Empty;
        Txt_Nome.Text = string.Empty;
        Txt_Plataforma.Text = string.Empty;
        Cmb_Genero.SelectedIndex = 0;
        Cmb_Ativo.SelectedIndex = 0;
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
            novaLista = todosOsJogos.Where(j => j.Id == id && j.Ativo == ativo).ToList();
            Dgv_Jogos.DataSource = novaLista.OrderBy(j => j.Id).ToList();
        }
    }
    private void Ckb_Favoritos_CheckedChanged(object sender, EventArgs e)
    {
        int ativo = ValidaStatusAtivo();
        if (Ckb_Favoritos.CheckState == CheckState.Checked)
        {
            todosOsJogosAux = todosOsJogos;
            todosOsJogos = jogosFavoritos;
            Dgv_Jogos.DataSource = jogosFavoritos.Where(j => j.Ativo == ativo).ToList();
        }
        if (Ckb_Favoritos.CheckState == CheckState.Unchecked)
        {
            todosOsJogos = todosOsJogosAux!;
            todosOsJogosAux = null;
            Dgv_Jogos.DataSource = todosOsJogos.Where(j => j.Ativo == ativo).ToList();
        }
    }
    private void PreencherComboBoxGenero()
    {
        Cmb_Genero.Items.Add("");
        foreach (var genero in Enum.GetValues(typeof(Genero)))
        {
            Cmb_Genero.Items.Add(genero);
        }
        Cmb_Genero.SelectedIndex = 0;
    }
    private void PreencheDataGridJogos()
    {
        Dgv_Jogos.DataSource = todosOsJogos.Where(j => j.Ativo == 1).ToList();
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
}
