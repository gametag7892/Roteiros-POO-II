using Exercicios1;

namespace Teste
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            var teste = new Carrinho();

            string nome = "Coca-cola";
            double preco = 12.00;

            teste.Adicionar(new Item {Nome = nome, Preco = preco});

            double resultado = teste.Total();

            Assert.Equal(preco, resultado);

        }

        [Fact]
        public void Test2()
        {

            var teste = new Carrinho();

            string nome = "Coca-cola";
            double preco = 12.00;

            teste.Adicionar(new Item { Nome = nome, Preco = preco });

            teste.Limpar();

            int qtd = teste.Quantidade();

            Assert.Empty();

        }
    }
}