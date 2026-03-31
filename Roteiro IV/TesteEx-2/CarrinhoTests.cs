using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using System.Reflection;

namespace TesteEx_2
{
    public class CarrinhoTests
    {

        Carrinho compras = new Carrinho();
        double somaTotal = 0;
        int quantidade = 0;

        Item item1 = new Item { Nome = "Maça", Preco = 5.50 };
        Item item2 = new Item { Nome = "Coca-cola", Preco = 15.50 };

        [Fact]
        public void VerificaTotal()
        {
            Item[] items = new Item[] { item1, item2 };

            foreach (Item item in items)
            {
                compras.Adicionar(item);
                somaTotal += item.Preco;

            }

            Assert.Equal(somaTotal, compras.Total());
        }

        public void VerificaQuantidade()
        {

            foreach (var a in compras.Itens)
            {
                quantidade += 1;
            }

            Assert.Equal(quantidade, compras.Quantidade());

        }

        public void VerificaCarrinhoVazio()
        {

            compras.Limpar();
            Assert.Empty(compras.Itens);
        }
    }
}