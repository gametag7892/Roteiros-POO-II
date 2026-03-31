namespace TesteEx_3
{
    public class UnitTest1
    {
        ConversorTemperatura temperatura = new ConversorTemperatura();
        double[] testsFahrenheit = [0, 100];
        double[] testsCelsius = [32, 212];
        double resultado;

        [Fact]
        public void VerificaFahrenheit()
        {
            for (int i = 0; i < testsFahrenheit.Length; i++)
            {
                resultado = temperatura.CelsiusParaFahrenheit(testsFahrenheit[i]);
                Assert.Equal(testsCelsius[i], resultado, 2);
            }
        }

        [Fact]
        public void VerificaCelsius()
        {
            for (int i = 0; i < testsFahrenheit.Length; i++)
            {
                resultado = temperatura.FahrenheitParaCelsius(testsCelsius[i]);
                Assert.Equal(testsFahrenheit[i], resultado, 2);
            }
        }
    }
}