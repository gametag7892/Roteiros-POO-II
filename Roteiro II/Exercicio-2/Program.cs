using System.IO;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

// Exercicio 2

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
            Console.WriteLine("O arquivo foi gerado! Verifique na pasta bin."); 
        }
    }
}
