public class DescontoService
{
    public double AplicarDesconto(double valor, double percentual)
    {
        if (valor < 0)
            throw new ArgumentException("Valor não pode ser negativo");
        if (percentual < 0 || percentual > 100)
            throw new ArgumentException("Percentual inválido");
        return valor - (valor * percentual / 100);
    }
}