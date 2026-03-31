public class Item
{
    public string Nome { get; set; }
    public double Preco { get; set; }
}
public class Carrinho
{
    private List<Item> itens = new();

    public IReadOnlyCollection<Item> Itens => itens.AsReadOnly(); // Permite a leitura da lista, sem modificá-la.
    public void Adicionar(Item item)
    {
        itens.Add(item);
    }
    public double Total()
    {
        return itens.Sum(i => i.Preco);
    }
    public int Quantidade()
    {
        return itens.Count;
    }
    public void Limpar()
    {
        itens.Clear();
    }
}