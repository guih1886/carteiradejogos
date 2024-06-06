using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogosForms.Classes.Interfaces;
using Newtonsoft.Json;

namespace CarteiraDeJogosForms.Forms.Usuario;

public partial class Form_Perfil : Form
{
    private IHttpClient _httpClientBuilder;
    private int usuarioId;
    private ReadUsuariosDto? usuario;
    public Form_Perfil(IHttpClient httpClient, int usuarioId)
    {
        this.usuarioId = usuarioId;
        _httpClientBuilder = httpClient;
        InitializeComponent();
        PreencherCamposDoUsuario();
    }

    private async void PreencherCamposDoUsuario()
    {
        HttpResponseMessage resposta = await _httpClientBuilder.GetRequisition($"/Usuarios/{usuarioId}");
        if (resposta.IsSuccessStatusCode)
        {
            string usuarioDto = await resposta.Content.ReadAsStringAsync();
            ReadUsuariosDto usuario = JsonConvert.DeserializeObject<ReadUsuariosDto>(usuarioDto)!;
            this.usuario = usuario;
            Txt_Id.Text = usuarioId.ToString();
            Txt_Nome.Text = usuario.Nome;
            Txt_Jogos.Text = JsonConvert.SerializeObject(usuario.Jogos.Order());
            Txt_JogosFavoritos.Text = JsonConvert.SerializeObject(usuario.JogosFavoritos.Order());
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
            UpdateUsuariosDto novoUsuario = new UpdateUsuariosDto(Txt_Nome.Text, usuario.Jogos, usuario.JogosFavoritos);
            HttpResponseMessage resposta = await _httpClientBuilder.PutRequisition($"/Usuarios/{usuarioId}", novoUsuario);
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
