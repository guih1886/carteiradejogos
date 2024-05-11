using AutoMapper.Configuration.Annotations;
using CarteiraDeJogos.Data.Dto.Usuarios;
using System.Net;
using System.Text.Json;
using Xunit.Abstractions;

namespace CarteiraDeJogosTest.ControllersTest
{
    public class UsuariosControllerTest
    {
        private HttpClientBuilder _httpClientBuilder = new HttpClientBuilder();

        [Fact]
        public async void CadastrarUsuarioTest()
        {
            //Arrange
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("Malaquias José", "1234", "1234");
            //Act
            string resposta = await _httpClientBuilder.CadastrarAsync<CreateUsuarioDto>("/Usuarios", novoUsuario);
            ReadUsuariosDto usuario = JsonSerializer.Deserialize<ReadUsuariosDto>(resposta)!;
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
            string resposta = await _httpClientBuilder.CadastrarAsync<CreateUsuarioDto>("/Usuarios", novoUsuario);
            //Assert
            Assert.Contains("As senhas não são iguais.", resposta);
        }

        [Fact]
        public void AlterarUsuarioTest()
        {
            //Arrange
            //Act
            //Assert
        }

        [Fact]
        public async void ListarUsuariosTest()
        {
            //Arrange
            //Act
            HttpResponseMessage resposta = await _httpClientBuilder.BuscarAsync("/Usuarios");
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
            string usuarioCriado = await _httpClientBuilder.CadastrarAsync<CreateUsuarioDto>("/Usuarios", novoUsuario);
            ReadUsuariosDto usuarioCriadoReadDto = JsonSerializer.Deserialize<ReadUsuariosDto>(usuarioCriado)!;
            HttpResponseMessage resposta = await _httpClientBuilder.BuscarAsync($"/Usuarios/{usuarioCriadoReadDto.Id}");
            ReadUsuariosDto usuario = JsonSerializer.Deserialize<ReadUsuariosDto>(resposta.Content.ReadAsStringAsync().Result)!;
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
            //Assert
            Assert.Equal(HttpStatusCode.NotFound, resposta.StatusCode);
        }

        [Fact]
        public async void DeletarUsuarioTest()
        {
            //Arrange
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("Malaquias José", "1234", "1234");
            //Act
            string usuarioCriado = await _httpClientBuilder.CadastrarAsync<CreateUsuarioDto>("/Usuarios", novoUsuario);
            ReadUsuariosDto usuario = JsonSerializer.Deserialize<ReadUsuariosDto>(usuarioCriado)!;
            HttpResponseMessage resposta = await _httpClientBuilder.DeletarAsync($"/Usuarios/{usuario.Id}");
            //Assert
            Assert.Equal(HttpStatusCode.NoContent, resposta.StatusCode);
        }

        [Fact]
        public async void DeletarUsuarioIncorretoTest()
        {
            //Arrange
            //Act
            HttpResponseMessage resposta = await _httpClientBuilder.DeletarAsync($"/Usuarios/0");
            //Assert
            Assert.Equal(HttpStatusCode.NotFound, resposta.StatusCode);
        }
    }
}
