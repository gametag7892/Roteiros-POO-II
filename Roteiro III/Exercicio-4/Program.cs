using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Linq;


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