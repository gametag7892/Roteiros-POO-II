using System.IO;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

//Exercicio 4


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
