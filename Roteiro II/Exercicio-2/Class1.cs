using System;
using System.Xml.Serialization;

// Exercicio 2 

[XmlRoot("estoque")]
public class Produtos
{
    [XmlElement("item")]
    public List<Produto> lista { get; set; }

}


public class Produto
{
    public string nome { get; set; }

    public double preco { get; set; }

    public int quantidade { get; set; }

}