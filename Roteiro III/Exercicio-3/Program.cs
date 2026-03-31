using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;

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

        List<Carros> carros = new List<Carros>();

        carros.Add(new Carros("Chevrolet", "Onix", 2010));
        carros.Add(new Carros("VolksWagen", "Gol", 2005));
        carros.Add(new Carros("Toyota", "Corola", 1998));

        string json = JsonConvert.SerializeObject(carros, Formatting.Indented);
        Console.WriteLine(json);
        File.WriteAllText("Carros.json", json);

        string conteudo = File.ReadAllText("Carros.json");

        List<Carros> carro = JsonConvert.DeserializeObject<List<Carros>>(conteudo);

        foreach (var c in carro)
        {
            Console.WriteLine($"Marca: {c.Marca}, Modelo: {c.Modelo}, Ano: {c.Ano}");
        }
    }
}