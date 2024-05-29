using CarteiraDeJogos.Controllers;
using CarteiraDeJogos.Data.Dto.Usuarios;
using CarteiraDeJogosTest.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Xunit.Abstractions;

namespace CarteiraDeJogosTest.ControllersTest
{
    public class UsuariosControllerTest
    {
        private UsuarioController controller;
        private ITestOutputHelper _outputHelper;

        public UsuariosControllerTest(ITestOutputHelper outputHelper)
        {
            controller = new UsuarioServiceProvider().AdicionarServico();
            _outputHelper = outputHelper;
        }

        [Fact]
        public void CadastrarUsuarioTest()
        {
            //Arrange
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("Malaquias José", "guilherme8@gmail.com", "1234", "1234");
            //Act
            var resposta = controller.CadastrarUsuario(novoUsuario);
            ReadUsuariosDto usuario = JsonConvert.DeserializeObject<ReadUsuariosDto>(resposta.Value.ToString());
            //Assert
            _outputHelper.WriteLine(usuario.ToString());
            Assert.Equal(201, resposta.StatusCode);
            Assert.IsType<ReadUsuariosDto>(usuario);
            DeletarUsuario(usuario);
        }
        [Fact]
        public void NaoCadastrarUsuarioComMesmoEmailTest()
        {
            //Arrange
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("Malaquias José", "guilherme2@gmail.com", "1234", "1234");
            CreateUsuarioDto novoUsuario2 = new CreateUsuarioDto("Malaquias José", "guilherme2@gmail.com", "1234", "1234");
            //Act
            var resposta = controller.CadastrarUsuario(novoUsuario);
            ReadUsuariosDto usuario = JsonConvert.DeserializeObject<ReadUsuariosDto>(resposta.Value.ToString());
            var resposta2 = controller.CadastrarUsuario(novoUsuario2);
            //Assert
            Assert.Equal(400, resposta.StatusCode);
            Assert.Equal("E-mail já cadastrado.", resposta2.Value);
            DeletarUsuario(usuario);
        }
        [Fact]
        public void NaoCadastraUsuarioComSenhaDivergenteTest()
        {
            //Arrange
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("Malaquias José", "guilherme3@gmail.com", "12345", "1234");
            IList<ValidationResult> valida = ValidarModelo(novoUsuario);
            //Act
            //Assert
            Assert.NotEmpty(valida);
        }
        [Fact]
        public void CadastrarUsuarioIncorretoTest()
        {
            //Arrange
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("Malaquias José", "guilherme3@gmail.com", "", "1234");
            //Act
            IList<ValidationResult> valida = ValidarModelo(novoUsuario);
            //Act
            //Assert
            Assert.NotEmpty(valida);

        }
        [Fact]
        public void AlterarUsuarioTest()
        {
            //Arrange
            ReadUsuariosDto usuario = CriarUsuario();
            UpdateUsuariosDto usuarioAlterado = new UpdateUsuariosDto("Usuario Alterado", [1, 2, 5, 8], [1, 2]);
            //Act
            ObjectResult resposta = controller.AlterarUsuario(usuario.Id, usuarioAlterado);
            ReadUsuariosDto alterado = JsonConvert.DeserializeObject<ReadUsuariosDto>(resposta.Value.ToString());
            _outputHelper.WriteLine(alterado.ToString());
            //Assert
            Assert.Equal(200, resposta.StatusCode);
            Assert.Equal("Usuario Alterado", alterado.Nome);
            DeletarUsuario(usuario);
        }
        [Fact]
        public void AlterarUsuarioIncorretoTest()
        {
            //Arrange
            UpdateUsuariosDto novoUsuario = new UpdateUsuariosDto("Usuario Alterado", [1, 2, 5, 8], [1, 2]);
            //Act
            ObjectResult resposta = controller.AlterarUsuario(0, novoUsuario);
            _outputHelper.WriteLine(resposta.Value.ToString());
            //Assert
            Assert.Equal(404, resposta.StatusCode);
            Assert.Equal("Usuário não encontrado.", resposta.Value);
        }
        [Fact]
        public void ListarUsuariosTest()
        {
            //Arrange
            //Act
            ObjectResult resposta = controller.ListarUsuarios();
            _outputHelper.WriteLine(resposta.Value.ToString());
            //Assert
            Assert.Equal(200, resposta.StatusCode);
            Assert.IsType<List<ReadUsuariosDto>>(resposta.Value);
        }
        [Fact]
        public void ListarUsuarioPorIdIncorretoTest()
        {
            //Arrange
            //Act
            ObjectResult resposta = controller.BuscarUsuarioPorId(0);
            _outputHelper.WriteLine(resposta.Value.ToString());
            //Assert
            Assert.Equal(404, resposta.StatusCode);
            Assert.Equal("Usuário não encontrado.", resposta.Value);
        }
        [Fact]
        public void ListarUsuarioPorIdTest()
        {
            //Arrange
            ReadUsuariosDto usuario = CriarUsuario();
            //Act
            var resposta = controller.BuscarUsuarioPorId(usuario.Id);
            _outputHelper.WriteLine(resposta.Value.ToString());
            //Assert
            Assert.Equal(200, resposta.StatusCode);
            DeletarUsuario(usuario);
        }
        [Fact]
        public void DeletarUsuarioTest()
        {
            //Arrange
            ReadUsuariosDto usuario = CriarUsuario();
            //Act
            ObjectResult resposta = controller.DeletarUsuario(usuario.Id);
            //Assert
            Assert.Equal(204, resposta.StatusCode);
            Assert.Equal("Usuário excluido com sucesso.", resposta.Value);
            DeletarUsuario(usuario);
        }
        [Fact]
        public void DeletarUsuarioIncorretoTest()
        {
            //Arrange
            //Act
            ObjectResult resposta = controller.DeletarUsuario(0);
            //Assert
            Assert.Equal(404, resposta.StatusCode);
            Assert.Equal("Usuário não encontrado.", resposta.Value);
        }

        private ReadUsuariosDto CriarUsuario()
        {
            CreateUsuarioDto novoUsuario = new CreateUsuarioDto("Malaquias José", "guilherme2@gmail.com", "1234", "1234");
            ObjectResult resposta = controller.CadastrarUsuario(novoUsuario);
            ReadUsuariosDto usuario = JsonConvert.DeserializeObject<ReadUsuariosDto>(resposta.Value.ToString()!)!;
            _outputHelper.WriteLine($"Usuario {usuario.Id} criado com sucesso.");
            return usuario;
        }
        private IList<ValidationResult> ValidarModelo(object model)
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            return validationResults;
        }
        private void DeletarUsuario(ReadUsuariosDto usuario)
        {
            controller.DeletarUsuario(usuario.Id);
            _outputHelper.WriteLine($"Usuario deletado {usuario.Id} com sucesso.");
        }
    }
}
