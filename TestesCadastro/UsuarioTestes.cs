using Cadastro;
using Xunit;
using Xunit.Abstractions;

namespace TestesCadastro
{
    public class UsuarioTestes
    {

        private Usuario usuario;
        public ITestOutputHelper SaidaUsuarioTestes;

        public UsuarioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaUsuarioTestes = _saidaConsoleTeste;
            SaidaUsuarioTestes.WriteLine("Construtor Invocado");
            usuario = new Usuario();

        }


        [Fact(DisplayName = "Teste de Nome de Usuário")]
        public void TesteNomeUsuario()
        {

            //Act
            usuario.Nome = "Fabio";

            //Assert
            Assert.Equal("Fabio", usuario.Nome);

        }

        [Fact(DisplayName = "Teste de CPF")]
        public void TesteCpfUsuario()
        {

            //Act
            usuario.Cpf = 123;

            //Assert
            Assert.Equal(123, usuario.Cpf);

        }
    }
}