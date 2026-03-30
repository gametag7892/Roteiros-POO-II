using System.IO;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

//  Exercicio 3

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
            Console.WriteLine("O arquivo foi modificado! Verifique no arquivo bin.");
        }
    }
}
