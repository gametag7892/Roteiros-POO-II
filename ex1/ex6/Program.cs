using System.Reflection;

class Program
{
    static void Main()
    {
        Console.Write("Digite um número: ");
        string texto = Console.ReadLine();

        try
        {
            int num = int.Parse(texto);
            Console.WriteLine($"Esse é seu número: {num}");
        }
        catch
        {
            throw new minhaMensagemException();
        }
        
    }
}

public class minhaMensagemException : FormatException {
    public minhaMensagemException()
        : base("Por gentileza, coloque um número em vez de uma letra.")
    {}
}
