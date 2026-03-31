internal class Program
{
    static void Main(string[] args)
    {
        var calc = new Calculadora();
        Console.WriteLine("=== Calculadora ===");
        Console.Write("Digite o primeiro número: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Digite o segundo número: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine($"\nSoma: {calc.Somar(a, b)}");
        Console.WriteLine($"Subtração: {calc.Subtrair(a, b)}");
        Console.WriteLine($"Multiplicação: {calc.Multiplicar(a, b)}");
        try
        {
            Console.WriteLine($"Divisão: {calc.Dividir(a, b)}");
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
        Console.WriteLine("\nPressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}

