public class CalculadoraIMC
{
    public double Calcular(double peso, double altura)
    {
        if (altura <= 0) throw new ArgumentException("Altura deve ser maior que zero");
    return peso / (altura * altura);
    }
    public string Classificar(double imc)
    {
        if (imc < 18.5) return "Abaixo do peso";
        if (imc < 25) return "Peso normal";
        if (imc < 30) return "Sobrepeso";
        return "Obesidade";
    }
}