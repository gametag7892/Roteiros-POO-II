using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

class Aluno
{
    public string Nome { get; set; }
    public string Curso { get; set; }
    public int Idade { get; set; }

    public Aluno(string nome, string curso, int idade)
    {
        Nome = nome; 
        Curso = curso;
        Idade = idade;
    }
}

class Program
{
    static void Main(string[] args)
    {

        List<Aluno> alunos = new List<Aluno>();

        alunos.Add(new Aluno("Eduardo", "SI", 20));
        alunos.Add(new Aluno("Brenno", "SI", 24));
        alunos.Add(new Aluno("Igor", "SI", 23));

        string json = JsonConvert.SerializeObject(alunos, Formatting.Indented);
        Console.WriteLine(json);
        File.WriteAllText("Aluno.json", json);

        string conteudo = File.ReadAllText("Aluno.json");

        List<Aluno> aluno = JsonConvert.DeserializeObject<List<Aluno>>(conteudo);

        foreach(var a in aluno)
        {
            Console.WriteLine($"Nome: {a.Nome}, Idade: {a.Idade}, Curso: {a.Curso}");
        }
    }
}