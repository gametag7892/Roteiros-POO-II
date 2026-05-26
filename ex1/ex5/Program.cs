class Program
{
    static void Main()
    {
        Conta conta1 = new Conta(100, "Maria", 100m);
        Conta conta2 = new Conta(400, "João", 100m);

        try
        {
            Console.WriteLine(conta1);

            conta1.Depositar(100);
            Console.WriteLine($"Saldo: {conta1.Saldo}");

            decimal[] retorno = conta1.Transferir(400, 100);

            if (Convert.ToDecimal(conta2.Numero) == retorno[0])
                conta2.Depositar(retorno[1]);

            Console.WriteLine($"Saldo: {conta1.Saldo}");
            Console.WriteLine($"Saldo: {conta2.Saldo}");

            conta1.Sacar(300);

            Console.WriteLine($"Saldo: {conta1.Saldo}");
        }
        catch (limiteDiarioException ex)
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
            //throw ex;  <- O Stack Trace original é perdido.

            throw;    // <- O correto para não perder o Stack Trace.
        }
    }
}

public class Conta
{
    public Conta(int numero, string titular, decimal saldo)
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
            if (valor > 500)
                throw new limiteDiarioException();
        }
        catch (Exception ex)
        {
            throw new limiteDiarioException(ex);
        }

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

    public decimal[] Transferir(int destino, decimal valor)
    {
        if (valor <= 0)
            throw new ArgumentException("Valor da transferência deve ser positivo");

        try
        {
            if (Saldo < valor)
                throw new Exception("Saldo insuficiente (erro interno)");

            Sacar(valor);

            return [Convert.ToDecimal(destino), valor];
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

    public SaldoInsuficienteException() { }

    public SaldoInsuficienteException(string message)
        : base(message) { }

    public SaldoInsuficienteException(string message, Exception inner)
        : base(message, inner) { }

    public SaldoInsuficienteException(decimal saque, decimal saldo, Exception inner)
        : base($"Saque de {saque} não permitido. Saldo atual: {saldo}", inner)
    {
        ValorSaque = saque;
        SaldoAtual = saldo;
    }

    public override string HelpLink
    {
        get => "https://meusistema.com/erros/saldo-insuficiente";
    }
}

[Serializable]
public class limiteDiarioException : Exception
{

    public limiteDiarioException()
    {

    }
    public limiteDiarioException(Exception inner)
        : base($"O saque maximo diario é de R$ 500,00.", inner)
    { }

    public override string HelpLink
    {
        get => "https://meusistema.com/erros/saldo-insuficiente";
    }
}