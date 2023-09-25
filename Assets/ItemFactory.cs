using System;
using UnityEngine;

public class ItemFactory : MonoBehaviour
{
    [SerializeField] private ItemBase _item;
    [SerializeField] private ItemIconConfig _spriteConfig;
    public ItemT Create<ItemT>(ItemType type, Vector2 position) where ItemT : ItemBase
    {
        ItemBase item = Instantiate<ItemBase>(_item);

        item.transform.position = position;

        item.Init(type, _spriteConfig.ItemsSprite[type]);

        return (ItemT)item;
    }

    public ItemT CreateRandomItem<ItemT>(Vector2 position) where ItemT : ItemBase
    {
        Array randomTypes = Enum.GetValues(typeof(ItemType));
        ItemType randomType = (ItemType)randomTypes.GetValue(UnityEngine.Random.Range(0, randomTypes.Length));

        return Create<ItemT>(randomType, position);
    }
}
