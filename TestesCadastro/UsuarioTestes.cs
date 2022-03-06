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

        [Fact(DisplayName = "Testa de criação de Usuário")]
        public void TesteUsuario()
        {

            //Arrange
            usuario.Nome = "Fabio";
            usuario.Cpf = 123;
            usuario.Idade = 26;
            usuario.Cidade = "São Paulo";

            //Act
            string dados = usuario.ToString();

            //Assert
            Assert.Contains("Dados do Usuário", dados);

        }

        [Theory]
        [InlineData("Fabio", 123, 26, "São Paulo")]
        [InlineData("Pedro", 456, 30, "Osasco")]
        [InlineData("João", 789, 40, "Barueri")]
        [InlineData("Marcos", 101112, 50, "Itapevi")]
        public void TestaDadosDeUsuarios(string nome,
                                         int cpf,
                                         int idade,
                                         string cidade)
        {

            //Arrange
            usuario.Nome = nome;
            usuario.Cpf = cpf;
            usuario.Idade = idade;
            usuario.Cidade = cidade;

            //Act
            string dados = usuario.ToString();

            //Assert
            Assert.Equal(nome, usuario.Nome);

        }

    }
}