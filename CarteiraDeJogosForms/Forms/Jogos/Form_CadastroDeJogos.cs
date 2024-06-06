using CarteiraDeJogos.Data.Dto.Jogos;
using CarteiraDeJogos.Models;
using CarteiraDeJogosForms.Classes;
using CarteiraDeJogosForms.Classes.Interfaces;
using CarteiraDeJogosForms.Classes.Utils;
using CarteiraDeJogosForms.Properties;
using Newtonsoft.Json;

namespace CarteiraDeJogosForms.Forms.Jogos;

public partial class Form_CadastroDeJogos : Form
{
    private IHttpClient _httpClientBuilder;
    private int usuarioId;
    private int jogoId;
    private List<int>? listaFavoritos;
    // status 0 = bloqueado; status 1 = criação de jogos; status 2 = alteração de jogos;
    private int toolStripNovoStatus = 0;
    public Form_CadastroDeJogos(IHttpClient httpClientBuilder, int usuarioId)
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
        Ckb_Favorito.Checked = false;
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
        Ckb_Favorito.Checked = false;
        Ckb_Favorito.Enabled = false;
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
        Pic_Jogo.ImageLocation = "";
    }
    private void PreencherFormulario(ReadJogosDto jogo)
    {
        AtivarFormulario();
        Ckb_Ativo.Enabled = true;
        Ckb_Favorito.Enabled = true;
        if (jogo.Ativo == 1) Ckb_Ativo.Checked = true;
        if (jogo.Ativo == 0) Ckb_Ativo.Checked = false;
        ValidaJogoFavorito();
        Txt_Nome.Text = jogo.Nome;
        Txt_Descricao.Text = jogo.Descricao;
        Txt_Imagem.Text = jogo.EnderecoImagem;
        Pic_Jogo.ImageLocation = jogo.EnderecoImagem;
        Mtb_AnoLancamento.Text = jogo.AnoLancamento;
        Txt_Plataforma.Text = jogo.Plataforma;
        Mtb_Nota.Text = jogo.Nota.ToString();
        Cmb_Genero.SelectedIndex = Cmb_Genero.FindStringExact(jogo.Genero);
    }
    private void Txt_Imagem_Leave(object sender, EventArgs e)
    {
        Pic_Jogo.ImageLocation = Txt_Imagem.Text;
    }
    private async void ValidaJogoFavorito()
    {
        HttpResponseMessage resposta = await _httpClientBuilder.GetRequisition($"/JogosDoUsuario/{usuarioId}/jogosfavoritos");
        List<int> listaFavoritos = JsonConvert.DeserializeObject<List<int>>(await resposta.Content.ReadAsStringAsync())!;
        this.listaFavoritos = listaFavoritos;
        if (listaFavoritos.Contains(jogoId)) Ckb_Favorito.Checked = true;
        if (!listaFavoritos.Contains(jogoId)) Ckb_Favorito.Checked = false;
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
            var resposta = await _httpClientBuilder.PostRequisition("/Jogos", novoJogo);
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
            int ativo = 0;
            if (Ckb_Ativo.Checked) ativo = 1;
            var genero = (Genero)Cmb_Genero.SelectedItem!;
            UpdateJogosDto novoJogo = new UpdateJogosDto(Txt_Imagem.Text, Txt_Nome.Text, Txt_Descricao.Text, genero, Mtb_AnoLancamento.Text, Txt_Plataforma.Text, Int32.Parse(Mtb_Nota.Text), ativo);
            HttpResponseMessage resposta = await _httpClientBuilder.PutRequisition($"/Jogos/{jogoId}", novoJogo);
            string msg = await ValidaRequisicao.CadastrarEAlterarJogo(resposta);
            if (listaFavoritos!.Contains(jogoId) && Ckb_Favorito.Checked == false) await _httpClientBuilder.DeleteRequisition($"/JogosDoUsuario/{usuarioId}/removerJogoFavorito/{jogoId}");
            if (!listaFavoritos!.Contains(jogoId) && Ckb_Favorito.Checked == true) await _httpClientBuilder.PostRequisition($"/JogosDoUsuario/{usuarioId}/adicionarJogoFavorito/{jogoId}", string.Empty);
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
            HttpResponseMessage response = await _httpClientBuilder.GetRequisition($"/Jogos/{buscar.jogoId}");
            if (response.IsSuccessStatusCode)
            {
                jogoId = buscar.jogoId;
                ReadJogosDto jogo = JsonConvert.DeserializeObject<ReadJogosDto>(await response.Content.ReadAsStringAsync())!;
                PreencherFormulario(jogo);
                toolStripNovoStatus = 2;
            }
        }
    }
    private void toolStripFavoritos_Click(object sender, EventArgs e)
    {
        Form jogosFavoritos = new Form_JogosFavoritos(_httpClientBuilder, usuarioId);
        jogosFavoritos.ShowDialog();
    }
    private async void toolStripDeletar_Click(object sender, EventArgs e)
    {
        if (toolStripNovoStatus == 2)
        {
            DialogResult resposta = MessageBox.Show("Deseja mesmo excluir o jogo?", "Excluir jogo", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (resposta == DialogResult.OK)
            {
                HttpResponseMessage response = await _httpClientBuilder.DeleteRequisition($"/Jogos/{jogoId}");
                if (response.IsSuccessStatusCode)
                {
                    DesativarFormulario();
                    MessageBox.Show("Jogo excluido com sucesso.", "Cadastro de Jogos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
        }
        else
        {
            DialogResult opcao = MessageBox.Show("Nenhum jogo selecionado.", "Cadastro de Jogos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
