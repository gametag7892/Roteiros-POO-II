using Exercicio_1;

namespace TesteEx_1
{
    public class ValidadorSenhaTests
    {
        ValidadorSenha senha = new ValidadorSenha();

        string[] senhas = ["Senha123", "12345678", "", "abcdEFGH"];

        [Fact]
        public void VerificaSenhasValidas()
        {
            
            foreach(var s in senhas)
            {
                var resultado = senha.EhValida(s);

                if (resultado == !true)
                { 
                    Assert.False(resultado);
                } 
            }
        }

        [Fact]
        public void VerificaSenhasInvalidas()
        {

            foreach (var s in senhas)
            {
                var resultado = senha.EhValida(s);

                if (resultado == true)
                {
                    Assert.True(resultado);
                }
                
            }
        }
    }
}