namespace TesteEx_0
{
    public class UnitTest1
    {
        //Questão a
        [Fact]
        public void Somar_DeveRetornar5()
        {
            var calc = new Calculadora();
            var resultado = calc.Somar(2, 3);

            //Assert.Equal(4, resultado); 
            // O Erro: O Assert.Equal(4, resultado) está esperando que 2 + 3 = 4.
            
            // Correção:
            Assert.Equal(5, resultado);
        }

        //Questão b
        [Fact]
        public void Dividir_DeveLancarExcecao()
        {
            var calc = new Calculadora();

            // Assert.Throws<DivideByZeroException>(() => calc.Dividir(10,2));
            // O Erro: O teste espera que uma exceção seja lançada ao dividir 10 por 2.

            // Correção:
            Assert.Throws<DivideByZeroException>(() => { calc.Dividir(10, 0); });
        }

        //Questão C
        [Fact]
        public void Carrinho_DeveEstarVazio()
        {
            var carrinho = new Carrinho();
            // carrinho.Adicionar(new Item { Nome = "Produto", Preco = 15 });
            // Assert.Empty(new List<Item> { new Item() });

            // O Erro: O Assert.Empty está verificando uma nova lista criada na hora, em vez de verificar a variável carrinho.
            // Além disso, o teste diz que deve estar vazio, mas o código adiciona um item.



            //Correção:

            //Remover a linha que adiciona o item no carrinho
            Assert.Empty(carrinho.Itens);
        }

        //Questão D
        [Fact]
        public void Classificar_DeveRetornarPesoNormal()
        {
            var calc = new CalculadoraIMC();

            //var resultado = calc.Classificar(31);
            //O Erro: O IMC 31 (Obesidade) está sendo comparado com "Peso normal".

            // Correção:
            var resultado = calc.Classificar(21);

            Assert.Equal("Peso normal", resultado);
        }
    }
}