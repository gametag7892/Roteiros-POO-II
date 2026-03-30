using System.IO;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

//Exercicio 1

/*
class Program
{
    static void Main()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Alunos));

        using (StreamReader reader = new StreamReader("alunos.xml"))
        {
            Alunos alunos = (Alunos)serializer.Deserialize(reader);

            foreach(var a in alunos.lista)
            {
                Console.WriteLine(a.nome);
                Console.WriteLine(a.curso);
            }
        }
    }
}
*/

// Exercicio 2

/*
class Program
{
    static void Main()
    {
        var loja = new Produtos
        {
            lista = new List<Produto>
            {
                new Produto {nome="Teclado", preco=15.60, quantidade=5},
                new Produto {nome="Mouse", preco=15.60, quantidade=3},
                new Produto {nome="Headphone", preco=90.00, quantidade=4},
            }
        };
        XmlSerializer serializer = new XmlSerializer(typeof(Produtos));

        using (StreamWriter write = new StreamWriter("Produtos.xml"))
        {
             serializer.Serialize(write, loja);
        }
    }
}
*/

//  Exercicio 3

/*
class Program
{
    static void Main()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Produtos));

        Produtos produto;

        using (StreamReader reader = new StreamReader("Produtos.xml"))
        {
            produto = (Produtos)serializer.Deserialize(reader);

            foreach(var p in produto.lista)
            {
                if (p.nome == "Mouse")
                {
                    p.quantidade = 10;
                }
            }
        }

        using (StreamWriter writer = new StreamWriter("Produtos.xml"))
        {
            serializer.Serialize(writer, produto);
        }
    }
}
*/

//Exercicio 4

/*
class Program
{
    private static HttpClient sharedClient = new()
    {
        BaseAddress = new Uri("https://www.w3schools.com/"),
    };

    static async Task GetAsync(HttpClient sharedClient)
    {
        var response = await sharedClient.GetStringAsync("xml/simple.xml");

        XmlSerializer serializer = new XmlSerializer(typeof(Comidas));

        Comidas comida;

        using (StringReader reader = new StringReader(response))
        {
            comida = (Comidas)serializer.Deserialize(reader);

            foreach (var c in comida.lista)
            {
                var turma = new Food
                {
                    comida = new List<Comida>
                    {
                        new Comida { name = c.name, price = c.price }
                    }
                };

                Console.WriteLine(c.name);
                Console.WriteLine(c.price);
                Console.WriteLine(turma.comida);
            }
        }
    }
    static async Task Main()
    {
        await GetAsync(sharedClient);
    }
}
*/
