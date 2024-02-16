public interface IItemService
{
    Item GetById(int id);
    void Add(Item item);
    bool Delete(int id);
}

public class ItemService : IItemService
{
    private readonly List<Item> _items;

    public ItemService()
    {
        _items = new List<Item>();
        // Here you would load your items from the JSON file
    }

    public Item GetById(int id) => _items.FirstOrDefault(i => i.Id == id);

    public void Add(Item item)
    {
        _items.Add(item);
    }

    public bool Delete(int id)
    {
        var item = GetById(id);
        if (item == null) return false;
        _items.Remove(item);
        return true;
    }
}
