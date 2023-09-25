using UnityEngine;

[CreateAssetMenu(fileName = "ItemIconConfig", menuName = "Item/new ItemIconConfig")]
public class ItemIconConfig : ScriptableObject
{
    [SerializeField] private SerializableDictionary<ItemType, Sprite> _itemsSprite;
    public SerializableDictionary<ItemType, Sprite> ItemsSprite => _itemsSprite;
}
