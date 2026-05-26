class Program
{
    static void Main()
    {
        Conta conta = new Conta(100, "Maria", 100m);

        try
        {
            Console.WriteLine(conta);

            conta.Depositar(100000);
            Console.WriteLine($"Saldo: {conta.Saldo}");

            conta.Sacar(200);

            Console.WriteLine($"Saldo: {conta.Saldo}");
        }
        catch (SaldoInsuficienteException ex)
        {
            Console.WriteLine("ERRO DE NEGÓCIO");
            Console.WriteLine(ex.Message);
            Console.WriteLine("Ajuda: " + ex.HelpLink);
            Console.WriteLine("StackTrace: " + ex.StackTrace);

            if (ex.InnerException != null)
            {
                Console.WriteLine("Causa: " + ex.InnerException.Message);
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Erro de validação: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro inesperado");
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
        }
    }
}

public class Conta { 
    public Conta (int numero, string titular, decimal saldo)
    {
        if (string.IsNullOrWhiteSpace(titular))
            throw new ArgumentNullException("Titular não pode ser vazio");
        if (saldo < 0)
            throw new ArgumentException("Saldo inicial não pode ser negativo");
        Numero = numero;
        Titular = titular;
        Saldo = saldo;
    }

    public int Numero { get; private set; }
    public string Titular { get; private set; }
    public decimal Saldo { get; private set; }

    public decimal Depositar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("Valor do deposito deve ser positivo");

        if (valor > 10000)
            throw new ArgumentException("Valor do deposito não pode passar de R$ 10.000,00");

        Saldo += valor;
        return Saldo;
    }

    public decimal Sacar(decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("Valor do saque deve ser positivo");

        try
        {
            if (Saldo < valor)
                throw new Exception("Saldo insuficiente (erro interno)");
            Saldo -= valor;
            return Saldo;
        }
        catch (Exception ex)
        {
            throw new SaldoInsuficienteException(valor, Saldo, ex);
        }
    }

    public override string ToString()
    {
        return $"Conta {Numero} - {Titular} - Saldo: {Saldo}";
    }
}

[Serializable]
public class SaldoInsuficienteException : Exception
{
    public decimal ValorSaque { get; }
    public decimal SaldoAtual { get; }

    public SaldoInsuficienteException() { 
        
    }

    public SaldoInsuficienteException(string message)
        : base(message) { }

    public SaldoInsuficienteException(string message, Exception inner)
        : base(message, inner) { }

    public SaldoInsuficienteException(decimal saque, decimal saldo, Exception inner)
        : base($"Saque de {saque} não permitido. Saldo atual: {saldo}", inner) {
        ValorSaque = saque;
        SaldoAtual = saldo;
    }

    public override string HelpLink 
    { 
        get => "https://meusistema.com/erros/saldo-insuficiente";
    }
}