using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

// Exercicio 1

/*
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
*/

// Exercicio 2

/*
class Aluno
{
    public string Nome { get; set; }
    public string Curso { get; set; }
    public int Idade { get; set; }

}

class Program
{
    static void Main(string[] args)
    {
       
        string conteudo = File.ReadAllText("Aluno.json");

        Aluno aluno = JsonConvert.DeserializeObject<Aluno>(conteudo);

        Console.WriteLine($"Nome: {aluno.Nome}, Idade: {aluno.Idade}, Curso: {aluno.Curso}");

    }
}
*/

// Exercicio 3

/*
class Carros
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Ano { get; set; }

    public Carros(string marca, string modelo, int ano)
    {
        Marca = marca;
        Modelo = modelo;
        Ano = ano;
    }
}

class Program
{
    static void Main(string[] args)
    {

        string conteudo = File.ReadAllText("Carros.json");

        List<Carros> carro = JsonConvert.DeserializeObject<List<Carros>>(conteudo);

        foreach (var c in carro)
        {
            Console.WriteLine($"Marca: {c.Marca}, Modelo: {c.Modelo}, Ano: {c.Ano}");
        }
    }
}
*/

// Exercicio 4

/*
class Program
{
    static void Main(string[] args)
    {

        string conteudo = File.ReadAllText("Servidor.json");

        JObject obj = JObject.Parse(conteudo);

        obj["Porta"] = 7070;
        Console.WriteLine(obj.ToString());
      
    }
}
*/

