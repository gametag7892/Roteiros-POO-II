using System;
using System.Xml.Serialization;

// Exercicio 4

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
