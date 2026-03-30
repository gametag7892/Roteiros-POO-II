using System;
using System.Xml.Serialization;

// Exercicio 1

using System.Xml.Serialization;
using System.Collections.Generic;

// Esta classe representa a tag <alunos>
[XmlRoot("alunos")]
public class ListaAlunos
{
    [XmlElement("aluno")]
    public List<Aluno> Alunos { get; set; }
}

// Esta classe representa cada tag <aluno>
public class Aluno
{
    [XmlElement("nome")]
    public string Nome { get; set; }

    [XmlElement("curso")]
    public string Curso { get; set; }
}


