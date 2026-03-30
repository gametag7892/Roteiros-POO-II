using System.Reflection.Metadata.Ecma335;

namespace BibliotecaConversao
{
    public class Conversao
    {
        public int Celsius(int a)
        {
            return (a * (9 / 5)) + 32;

        }

        public int Fahrenheit(int a)
        {
            return (a - 32) * 5 / 9;
        }

        public int Metros(int a)
        {
            return a / 1000;
        }

        public int Kilometros(int a)
        {
            return a * 1000;
        }

        public decimal Moedas(decimal a, decimal b)
        {
            return a / b;
        }
    }    

}
