using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Models;
using CarteiraDeJogosForms.Classes;
using CarteiraDeJogosForms.Classes.Utils;
using CarteiraDeJogosForms.Properties;

namespace CarteiraDeJogosForms.Forms.Jogos;

public partial class Form_CadastrarJogo : Form
{
    private HttpClientBuilder _httpClientBuilder;
    private int usuarioId;
    private int toolStripNovoStatus = 0;
    public Form_CadastrarJogo(HttpClientBuilder httpClientBuilder, int usuarioId)
    {
        _httpClientBuilder = httpClientBuilder;
        this.usuarioId = usuarioId;
        InitializeComponent();
        foreach (var genero in Enum.GetValues(typeof(Genero)))
        {
            Cmb_Genero.Items.Add(genero);
        }
        Cmb_Genero.SelectedIndex = 0;
        Txt_UsuarioId.Text = usuarioId.ToString();
        Mtb_AnoLancamento.Text = "0000";
        Mtb_Nota.Text = "00";
    }

    private void AtivarFormulario()
    {
        Txt_Nome.ReadOnly = false;
        Txt_Descricao.ReadOnly = false;
        Txt_Imagem.ReadOnly = false;
        Cmb_Genero.Enabled = true;
        Mtb_AnoLancamento.ReadOnly = false;
        Txt_Plataforma.ReadOnly = false;
        Mtb_Nota.ReadOnly = false;
        toolStripNovo.Text = "Cancelar";
        toolStripNovo.Image = Resources.cancelarArquivo;
        toolStripNovoStatus = 1;
        Txt_Nome.Focus();
    }
    private void DesativarFormulario()
    {
        LimparFormulario();
        Txt_Nome.ReadOnly = true;
        Txt_Descricao.ReadOnly = true;
        Txt_Imagem.ReadOnly = true;
        Cmb_Genero.SelectedIndex = 0;
        Cmb_Genero.Enabled = false;
        Mtb_AnoLancamento.ReadOnly = true;
        Txt_Plataforma.ReadOnly = true;
        Mtb_Nota.ReadOnly = true;
        toolStripNovo.Text = "Novo";
        toolStripNovo.Image = Resources.novo;
        toolStripNovoStatus = 0;
        Gpb_DadosJogos.Focus();
    }
    private void LimparFormulario()
    {
        Txt_Nome.Text = "";
        Txt_Descricao.Text = "";
        Txt_Imagem.Text = "";
        Cmb_Genero.SelectedIndex = -1;
        Mtb_AnoLancamento.Text = "";
        Txt_Plataforma.Text = "";
        Mtb_Nota.Text = "";
        Cmb_Genero.SelectedIndex = 0;
        Mtb_AnoLancamento.Text = "0000";
        Mtb_Nota.Text = "00";
        Txt_Nome.Focus();
        Lbl_Erro.Text = "";
    }
    private void toolStripNovo_Click(object sender, EventArgs e)
    {
        if (toolStripNovoStatus == 0)
        {
            AtivarFormulario();
        }
        else
        {
            DialogResult opcao = MessageBox.Show("Deseja mesmo cancelar a inclusão?", "Cadastro de Jogos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (opcao == DialogResult.OK) DesativarFormulario();
        }

    }
    private void toolStripReset_Click(object sender, EventArgs e)
    {
        LimparFormulario();
    }
    private async void toolStripSalvar_Click(object sender, EventArgs e)
    {
        if (toolStripNovoStatus == 0)
        {
            DialogResult opcao = MessageBox.Show("Clique em 'Novo' para adicionar um jogo.", "Cadastro de Jogos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (opcao == DialogResult.Cancel) this.Close();
        }
        else
        {
            var genero = (Genero)Cmb_Genero.SelectedItem!;
            CreateJogosDto novoJogo = new CreateJogosDto(Txt_Imagem.Text, Txt_Nome.Text, Txt_Descricao.Text, genero, usuarioId, Mtb_AnoLancamento.Text, Txt_Plataforma.Text, Int32.Parse(Mtb_Nota.Text));
            var resposta = await _httpClientBuilder.PostReq("/Jogos", novoJogo);
            string msg = await ValidaRequisicao.CadastrarJogo(resposta);
            if (!resposta.IsSuccessStatusCode)
            {
                Lbl_Erro.Text = msg;
            }
            else
            {
                MessageBox.Show("Jogo Cadastrado com sucesso!", "Cadastro de Jogos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimparFormulario();
                DesativarFormulario();
            }
        }

    }
}
