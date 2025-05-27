using System;
using System.Collections.Generic;


public interface IItemRepository
{
    IReadOnlyList<Item> FindAll();
    Item FindBy(int id);
}

// Item 관련 Persistency를 담당
public class JsonItemRepository : IItemRepository
{
    private List<Item> _items;

    public JsonItemRepository()
    {
        _items = LoadItems();
    }


    public IReadOnlyList<Item> FindAll() => _items.AsReadOnly();

    // DTO: Data Transfor object

    private List<Item> LoadItems()
    {
        
    }

    public Item FindBy(int id)
    {
        return _items.Find(item => item.Id == id);
    }
}