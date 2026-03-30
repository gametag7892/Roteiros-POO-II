using BibliotecaFinanceira;


namespace DLLteste;
class Program
{
    public static void Main()
    {
        var calc = new CalculadoraJuros();

        calc.JurosSimples(10);

        // a) Por que o método internal não aparece? 
        // R: O método internal não aparece (ou não fica visível) porque o modificador de acesso internal
        // restringe a visibilidade de classes e métodos ao mesmo assembly (projeto/DLL). 
    }
}