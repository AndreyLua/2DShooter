using System;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    private List<ItemBase> _items;

    public List<ItemBase> Items => _items;

    public event Action<ItemBase> BagAddedItem;
    public event Action<ItemBase> BagRemovingItem;

    private void Awake()
    {
        _items = new List<ItemBase>();
    }

    public void AddedItem(ItemBase item)
    {
        _items.Add(item);
        BagAddedItem?.Invoke(item);
    }

    public void RemoveItem(ItemBase item)
    {
        BagRemovingItem?.Invoke(item);
        _items.Remove(item);
    }

    public void RemoveItemOfType(ItemType type)
    {
        for (int i = _items.Count - 1; i >= 0; i--)
            if (_items[i].Type == type)
                RemoveItem(_items[i]);
    }
}
