using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Models;
using CarteiraDeJogosForms.Classes;
using CarteiraDeJogosForms.Classes.Utils;
using CarteiraDeJogosForms.Properties;
using Newtonsoft.Json;

namespace CarteiraDeJogosForms.Forms.Jogos;

public partial class Form_CadastroDeJogos : Form
{
    private HttpClientBuilder _httpClientBuilder;
    private int usuarioId;
    private int jogoId;
    // status 0 = bloqueado; status 1 = criação de jogos; status 2 = alteração de jogos;
    private int toolStripNovoStatus = 0;
    public Form_CadastroDeJogos(HttpClientBuilder httpClientBuilder, int usuarioId)
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
        Ckb_Ativo.Checked = true;
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
        Ckb_Ativo.Checked = false;
        Ckb_Ativo.Enabled = false;
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
    private void PreencherFormulario(ReadJogosDto jogo)
    {
        AtivarFormulario();
        Ckb_Ativo.Enabled = true;
        if (jogo.Ativo == 1) Ckb_Ativo.Checked = true;
        if (jogo.Ativo == 0) Ckb_Ativo.Checked = false;
        Txt_Nome.Text = jogo.Nome;
        Txt_Descricao.Text = jogo.Descricao;
        Txt_Imagem.Text = jogo.EnderecoImagem;
        Mtb_AnoLancamento.Text = jogo.AnoLancamento;
        Txt_Plataforma.Text = jogo.Plataforma;
        Mtb_Nota.Text = jogo.Nota.ToString();
        Cmb_Genero.SelectedIndex = Cmb_Genero.FindStringExact(jogo.Genero);
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
        if (toolStripNovoStatus == 1)
        {
            var genero = (Genero)Cmb_Genero.SelectedItem!;
            CreateJogosDto novoJogo = new CreateJogosDto(Txt_Imagem.Text, Txt_Nome.Text, Txt_Descricao.Text, genero, usuarioId, Mtb_AnoLancamento.Text, Txt_Plataforma.Text, Int32.Parse(Mtb_Nota.Text));
            var resposta = await _httpClientBuilder.PostReq("/Jogos", novoJogo);
            string msg = await ValidaRequisicao.CadastrarEAlterarJogo(resposta);
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
        if (toolStripNovoStatus == 2)
        {
            var genero = (Genero)Cmb_Genero.SelectedItem!;
            UpdateJogosDto novoJogo = new UpdateJogosDto(Txt_Imagem.Text, Txt_Nome.Text, Txt_Descricao.Text, genero, Mtb_AnoLancamento.Text, Txt_Plataforma.Text, Int32.Parse(Mtb_Nota.Text));
            HttpResponseMessage resposta = await _httpClientBuilder.PutReq($"/Jogos/{jogoId}", novoJogo);
            string msg = await ValidaRequisicao.CadastrarEAlterarJogo(resposta);
            if (!resposta.IsSuccessStatusCode)
            {
                Lbl_Erro.Text = msg;
            }
            else
            {
                MessageBox.Show("Jogo Alterado com sucesso.", "Cadastro de Jogos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimparFormulario();
                DesativarFormulario();
            }
        }
    }
    private async void toolStripBuscar_Click(object sender, EventArgs e)
    {
        List<ReadJogosDto> lista = await BuscarJogosDoUsuario.BuscarTodosJogosDoUsuario(_httpClientBuilder, usuarioId);
        Form_BuscarJogo buscar = new Form_BuscarJogo(_httpClientBuilder, usuarioId, lista);
        DialogResult resposta = buscar.ShowDialog();
        if (resposta == DialogResult.OK)
        {
            HttpResponseMessage response = await _httpClientBuilder.GetJogo(buscar.jogoId);
            if (response.IsSuccessStatusCode)
            {
                jogoId = buscar.jogoId;
                ReadJogosDto jogo = JsonConvert.DeserializeObject<ReadJogosDto>(await response.Content.ReadAsStringAsync())!;
                PreencherFormulario(jogo);
                toolStripNovoStatus = 2;
            }
        }
    }
}
