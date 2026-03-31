using Exercicio_5;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;

public class Program
{
    static void Main()
    {
        List<Produto> produtos = new List<Produto>();

        produtos.Add(new Produto ( 1, "Notebook",  2800.00, 100, "Dell", "AKFJHAF124125" ));
        produtos.Add(new Produto ( 2, "Mouse", 500.00, 100, "Logitech", "FGKQBWFU124125" ));
        produtos.Add(new Produto ( 3, "Teclado", 800.00, 100, "RedDragon", "FGAENGLKA24125" ));

        try
        {
            string json = JsonConvert.SerializeObject(produtos, Formatting.Indented);
            Console.WriteLine(json);
            File.WriteAllText("produtos.json", json);

            string conteudo = File.ReadAllText("produtos.json");
            List<Produto> produto = JsonConvert.DeserializeObject<List<Produto>>(conteudo);

            foreach (var p in produto)
            {
                Console.WriteLine($"Id: {p.Id}, Nome: {p.Nome}, Preço: {p.Preco}, Estoque: {p.Estoque}, Fornecedor: {p.Fornecedor}");
            }

        }
        catch (JsonSerializationException ex)
        {
            Console.WriteLine($"Ocorreu um erro: {ex.Message}");
        }
    }
}