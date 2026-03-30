using System;
using BibliotecaConversao; //   Namespace da DLL

namespace TesteDLL
{
    class Program
    {
        
        static void Main()
        {
            var calc = new Conversao();

            Console.WriteLine("Digite o número (em metros):");
            int kilometer = int.Parse(Console.ReadLine());

            Console.Write("Valor em KM(s):");
            Console.WriteLine(calc.Metros(kilometer) + "Km");

            Console.WriteLine("Digite o número (em kilometros):");
            int meter = int.Parse(Console.ReadLine());

            Console.Write("Valor em Metro(s):");
            Console.WriteLine(calc.Kilometros(meter) + "m");

            Console.WriteLine("Digite a temperatura (em celsius):");
            int celsius = int.Parse(Console.ReadLine());

            Console.Write("Temperatura em Celsius:");
            Console.WriteLine(calc.Celsius(celsius) + "ºF");

            Console.WriteLine("Digite o número (em Fahrenheit):");
            int fahrenheit = int.Parse(Console.ReadLine());

            Console.Write("Temperatura em Fahrenheit:");
            Console.WriteLine(calc.Fahrenheit(fahrenheit) + "ºC");

            Console.WriteLine("Digite o valor da moeda:");
            decimal valorMoeda = decimal.Parse(Console.ReadLine());

            Console.Write("Digite o valor do câmbio:");
            decimal taxaCambio = decimal.Parse(Console.ReadLine());

            Console.Write("Resultado do calculo:");
            Console.WriteLine(calc.Moedas(valorMoeda, taxaCambio));

        }
    }
}