using System;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    private List<ItemBase> _items;

    public event Action BagChanged;

    private void Awake()
    {
        _items = new List<ItemBase>();
    }

    public void AddedItem(ItemBase item)
    {
        _items.Add(item);
        BagChanged?.Invoke();
    }

    public void RemoveItem(ItemBase item)
    {
        _items.Remove(item);
        BagChanged?.Invoke();
    }
}
