namespace TesteEx_4
{
    public class CalculadoraIMCTests
    {

        CalculadoraIMC calculoIMC = new CalculadoraIMC();

        double resultado;
        double altura = 1.75;
        double peso = 70;
        double[] classificar = [17, 26];

        [Fact]
        public void VerificarCalculo()
        {
            resultado = calculoIMC.Calcular(peso, altura);
            Assert.Equal(22.86, resultado, 2);
        }

        [Fact]
        public void VerificarClassificacao()
        {

            for (int i = 0; i < classificar.Length; i++)
            {
                string[] resultados = ["Abaixo do peso", "Sobrepeso"];
                string results = calculoIMC.Classificar(classificar[i]);
                Assert.Equal(resultados[i], results);
            }

        }

        [Fact]
        public void VerificarException()
        {
            Assert.Throws<ArgumentException>(() => {
                double testeModificado = calculoIMC.Calcular(peso, 0);
            });
        }
    }
}