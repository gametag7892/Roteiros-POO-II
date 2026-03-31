using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio_5
{
    public class Produto
    {
        public Produto(int id, string nome, double preco, int estoque, string fornecedor, string codigointerno)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            Estoque = estoque;
            Fornecedor = fornecedor;
            CodigoInterno = codigointerno;
        }

        public int Id { get; set; }
        [JsonProperty("product_name", Required = Required.Always)]
        public string Nome { get; set; }
        [JsonProperty("product_price", Required = Required.Always)]
        public double Preco { get; set; }
        public int Estoque { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Fornecedor { get; set; }
        
        [JsonIgnore]
        public string CodigoInterno { get; set; }
    }
}
