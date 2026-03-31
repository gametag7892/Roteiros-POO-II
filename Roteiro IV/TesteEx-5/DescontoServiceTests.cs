using System.Reflection;

namespace TesteEx_5
{
    public class DescontoServiceTests
    {

        DescontoService desconto = new DescontoService();


        double[] valores = [100, 200, 80];
        double[] percentuais = [10, 50, 0];
        double[] resultados = [90, 100, 80];


        [Fact]
        public void VerificarResultados()
        {
            for (int i = 0; i < valores.Length; i++)
            {
                double resultado = desconto.AplicarDesconto(valores[i], percentuais[i]);

                Assert.Equal(resultados[i], resultado);
            }
        }

        [Fact]
        public void VerificarValorNegativo()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                double resultado = desconto.AplicarDesconto(-1, 100);
            });
        }

        [Fact]
        public void VerificarPorcentagemNegativo()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                double resultado = desconto.AplicarDesconto(10, -1);
            });
        }

        [Fact]
        public void VerificarPorcentagemAcima()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                double resultado = desconto.AplicarDesconto(10, 101);
            });
        }


        [Theory]
        [InlineData(100, 10, 90)]
        [InlineData(200, 50, 100)]
        [InlineData(80, 0, 80)]
        public void TheoryVerificarResultados(double a, double b, double esperado)
        {
            double resultado = desconto.AplicarDesconto(a, b);
            Assert.Equal(esperado, resultado);   
        }

        [Theory]
        [InlineData (-1, 100)]
        public void TheoryVerificarValorNegativo(double a, double b)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                double resultado = desconto.AplicarDesconto(a, b);
            });
        }

        [Theory]
        [InlineData(10, -1)]
        public void TheoryVerificarPorcentagemNegativo(double a, double b)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                double resultado = desconto.AplicarDesconto(a, b);
            });
        }

        [Theory]
        [InlineData (10, 101)]
        public void VTheoryerificarPorcentagemAcima(double a, double b)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                double resultado = desconto.AplicarDesconto(a, b);
            });
        }

    }
}