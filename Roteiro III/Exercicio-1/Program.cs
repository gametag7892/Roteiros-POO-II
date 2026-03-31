using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

class Livro
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int Ano { get; set; }

}

class Program
{
    static void Main(string[] args)
    {
        var livro = new Livro
        {
            Titulo = "Senhor dos Aneis",
            Autor = "J. R. R. Tolkien",
            Ano = 1954
        };

        string json = JsonConvert.SerializeObject(livro, Formatting.Indented);
        

        Console.WriteLine(json);

    }
}