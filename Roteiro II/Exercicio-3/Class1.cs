using System;
using System.Xml.Serialization;

// Exercicio 3


[XmlRoot("estoque")]
public class Produtos
{
    [XmlElement("item")]
    public List<Produto> lista { get; set; }

}

public class Produto
{
    public string nome { get; set; }

    public int quantidade { get; set; }

}