using CarteiraDeJogos.Data.Dto.Usuarios;
using System.Net;
using System.Text.Json;
using Xunit.Abstractions;

namespace CarteiraDeJogosTest.ControllersTest
{
    public class UsuariosControllerTest
    {
        private HttpClientBuilder _httpClientBuilder = new HttpClientBuilder();
        private ITestOutputHelper _outputHelper;

        public UsuariosControllerTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public async void CadastrarUsuarioTest()
        {
            //Arrange
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("Malaquias José", "1234", "1234");
            //Act
            HttpResponseMessage resposta = await _httpClientBuilder.CadastrarAsync<CreateUsuarioDto>("/Usuarios", novoUsuario);
            ReadUsuariosDto usuario = JsonSerializer.Deserialize<ReadUsuariosDto>(resposta.Content.ReadAsStringAsync().Result)!;
            _outputHelper.WriteLine(usuario.Id.ToString());
            //Assert
            Assert.Equal("Malaquias José", usuario.Nome);
            await _httpClientBuilder.DeletarAsync($"/Usuarios/{usuario.Id}");
        }

        [Fact]
        public async void CadastrarUsuarioIncorretoTest()
        {
            //Arrange
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("Malaquias José", "123456", "1234");
            //Act
            HttpResponseMessage resposta = await _httpClientBuilder.CadastrarAsync<CreateUsuarioDto>("/Usuarios", novoUsuario);
            _outputHelper.WriteLine(resposta.Content.ReadAsStringAsync().Result);
            //Assert
            Assert.Contains("As senhas não são iguais.", resposta.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async void AlterarUsuarioTest()
        {
            //Arrange
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("Malaquias José", "1234", "1234");
            UpdateUsuariosDto usuarioAlterado = new UpdateUsuariosDto("Usuario Alterado", [1, 2, 5, 8], [1, 2]);
            //Act
            HttpResponseMessage novoUsuarioDTO = await _httpClientBuilder.CadastrarAsync<CreateUsuarioDto>("/Usuarios", novoUsuario);
            ReadUsuariosDto readNovoUsuarioDTO = JsonSerializer.Deserialize<ReadUsuariosDto>(novoUsuarioDTO.Content.ReadAsStringAsync().Result)!;

            HttpResponseMessage resposta = await _httpClientBuilder.AlterarAsync<UpdateUsuariosDto>($"/Usuarios/{readNovoUsuarioDTO.Id}", usuarioAlterado);
            ReadUsuariosDto usuario = JsonSerializer.Deserialize<ReadUsuariosDto>(resposta.Content.ReadAsStringAsync().Result)!;
            _outputHelper.WriteLine(usuario.Nome);
            //Assert
            Assert.Equal("Usuario Alterado", usuario.Nome);
            await _httpClientBuilder.DeletarAsync($"/Usuarios/{readNovoUsuarioDTO.Id}");
        }

        [Fact]
        public async void AlterarUsuarioIncorretoTest()
        {
            //Arrange
            UpdateUsuariosDto novoUsuario = new UpdateUsuariosDto("Usuario Alterado", [1, 2, 5, 8], [1, 2]);
            //Act
            HttpResponseMessage resposta = await _httpClientBuilder.AlterarAsync<UpdateUsuariosDto>("/Usuarios/0", novoUsuario);
            _outputHelper.WriteLine(resposta.Content.ReadAsStringAsync().Result);
            //Assert
            Assert.Contains("Not Found", resposta.Content.ReadAsStringAsync().Result);
        }

        [Fact]
        public async void ListarUsuariosTest()
        {
            //Arrange
            //Act
            HttpResponseMessage resposta = await _httpClientBuilder.BuscarAsync("/Usuarios");
            _outputHelper.WriteLine(resposta.ToString());
            //Assert
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
        }

        [Fact]
        public async void ListarUsuarioPorIdTest()
        {
            //Arrange
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("Malaquias José", "1234", "1234");
            //Act
            //Act
            HttpResponseMessage usuarioCriado = await _httpClientBuilder.CadastrarAsync<CreateUsuarioDto>("/Usuarios", novoUsuario);
            ReadUsuariosDto usuarioCriadoReadDto = JsonSerializer.Deserialize<ReadUsuariosDto>(usuarioCriado.Content.ReadAsStringAsync().Result)!;
            HttpResponseMessage resposta = await _httpClientBuilder.BuscarAsync($"/Usuarios/{usuarioCriadoReadDto.Id}");
            ReadUsuariosDto usuario = JsonSerializer.Deserialize<ReadUsuariosDto>(resposta.Content.ReadAsStringAsync().Result)!;
            _outputHelper.WriteLine(usuario.Id.ToString());
            //Assert
            Assert.Equal(HttpStatusCode.OK, resposta.StatusCode);
            Assert.Equal(usuarioCriadoReadDto.Id, usuario.Id);
            await _httpClientBuilder.DeletarAsync($"/Usuarios/{usuario.Id}");
        }

        [Fact]
        public async void ListarUsuarioPorIdIncorretoTest()
        {
            //Arrange
            //Act
            HttpResponseMessage resposta = await _httpClientBuilder.BuscarAsync($"/Usuarios/0");
            _outputHelper.WriteLine(resposta.ToString());
            //Assert
            Assert.Equal(HttpStatusCode.NotFound, resposta.StatusCode);
        }

        [Fact]
        public async void DeletarUsuarioTest()
        {
            //Arrange
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("Malaquias José", "1234", "1234");
            //Act
            HttpResponseMessage usuarioCriado = await _httpClientBuilder.CadastrarAsync<CreateUsuarioDto>("/Usuarios", novoUsuario);
            ReadUsuariosDto usuario = JsonSerializer.Deserialize<ReadUsuariosDto>(usuarioCriado.Content.ReadAsStringAsync().Result)!;
            HttpResponseMessage resposta = await _httpClientBuilder.DeletarAsync($"/Usuarios/{usuario.Id}");
            _outputHelper.WriteLine(resposta.ToString());
            //Assert
            Assert.Equal(HttpStatusCode.NoContent, resposta.StatusCode);
        }

        [Fact]
        public async void DeletarUsuarioIncorretoTest()
        {
            //Arrange
            //Act
            HttpResponseMessage resposta = await _httpClientBuilder.DeletarAsync($"/Usuarios/0");
            _outputHelper.WriteLine(resposta.ToString());
            //Assert
            Assert.Equal(HttpStatusCode.NotFound, resposta.StatusCode);
        }
    }
}
