using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogosForms.Classes;
using Newtonsoft.Json;

namespace CarteiraDeJogosForms.Forms.Usuario;

public partial class Form_Perfil : Form
{
    private int usuarioId;
    private HttpClientBuilder _httpClientBuilder;
    private ReadUsuariosDto? usuario;
    private List<int>? jogos;
    private List<int>? jogosFavoritos;
    public Form_Perfil(HttpClientBuilder httpClient, int usuarioId)
    {
        this.usuarioId = usuarioId;
        _httpClientBuilder = httpClient;
        InitializeComponent();
        PreencherCamposDoUsuario();
    }

    private async void PreencherCamposDoUsuario()
    {
        HttpResponseMessage resposta = await _httpClientBuilder.GetUsuario(usuarioId);
        string obj = await resposta.Content.ReadAsStringAsync();
        if (resposta.IsSuccessStatusCode)
        {
            ReadUsuariosDto usuario = JsonConvert.DeserializeObject<ReadUsuariosDto>(obj)!;
            this.usuario = usuario;
            jogos = usuario.Jogos;
            jogosFavoritos = usuario.JogosFavoritos;
            Txt_Id.Text = usuario.Id.ToString();
            Txt_Nome.Text = usuario.Nome;
            Txt_Jogos.Text = JsonConvert.SerializeObject(jogos);
            Txt_JogosFavoritos.Text = JsonConvert.SerializeObject(jogosFavoritos);
        }
        else
        {
            MessageBox.Show(obj, "Buscar Usuário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }
    }
    private void toolStripEditar_Click(object sender, EventArgs e)
    {
        Txt_Nome.ReadOnly = false;
        Txt_Nome.Focus();
    }
    private async void toolStripSalvar_Click(object sender, EventArgs e)
    {
        Txt_Nome.ReadOnly = true;
        if (usuario!.Nome != Txt_Nome.Text)
        {
            UpdateUsuariosDto novoUsuario = new UpdateUsuariosDto(Txt_Nome.Text, jogos, jogosFavoritos);
            HttpResponseMessage resposta = await _httpClientBuilder.PutReq($"/Usuarios/{usuarioId}", novoUsuario);
            if (resposta.IsSuccessStatusCode)
            {
                MessageBox.Show("Usuário alterado com sucesso.", "Alteração de usuário", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(await resposta.Content.ReadAsStringAsync(), "Alteração de usuário", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
