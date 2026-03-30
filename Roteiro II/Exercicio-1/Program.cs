using System.IO;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

//Exercicio 1

class Program
{
    static void Main()
    {
        XmlSerializer serializer = new XmlSerializer(typeof(ListaAlunos));

        using (StreamReader reader = new StreamReader("alunos.xml"))
        {
            ListaAlunos alunos = (ListaAlunos)serializer.Deserialize(reader);

            foreach(var a in alunos.Alunos)
            {
                Console.WriteLine(a.Nome);
                Console.WriteLine(a.Curso);
            }
        }
    }
}
