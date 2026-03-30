using System;
using System.Xml.Serialization;

// Exercicio 1
/*
public class Aluno
{
    public string nome { get; set; }
    public string curso { get; set; }
}
*/


// Exercicio 2 & 3

/*
[XmlRoot("estoque")]
public class Produtos
{
    [XmlElement("item")]
    public List<Produto> lista { get; set; }

}
*/

/*
public class Produto
{
    public string nome { get; set; }

    public int quantidade { get; set; }

}
*/


// Exercicio 4

/*
[XmlRoot("breakfast_menu")]
public class Comidas
{
    [XmlElement("food")]
    public List<Comida> lista { get; set; }

}

public class Comida
{
    public string name { get; set; }

    public string price { get; set; }

}
class Food
{
    public List<Comida> comida { get; set; }
}
*/