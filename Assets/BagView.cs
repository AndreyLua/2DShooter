using System.Collections.Generic;
using UnityEngine;

public class BagView : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private ItemView _itemView;
    [SerializeField] private RectTransform _transformParent;
    [SerializeField] private Vector2 _startFreePosition;

    private Queue<Vector2> _freePositions;
    private Dictionary<Vector2, ItemView> _viewItems;
    private Dictionary<ItemType, ItemView> _typeItems;

    private void Awake()
    {
        _freePositions = new Queue<Vector2>();

        for (int i = 0; i < 10; i++)
            _freePositions.Enqueue(_startFreePosition + new Vector2(i*10,0));

        _viewItems = new Dictionary<Vector2, ItemView>();
        _bag.BagAddedItem += OnBagAddedItem;
        _bag.BagRemovingItem += OnBagRemovingItem;
    }

    private void OnBagAddedItem(ItemBase item)
    {
        Vector2 position = _freePositions.Dequeue();
        _viewItems[position] = Instantiate<ItemView>(_itemView);
        _viewItems[position].transform.SetParent(_transformParent);
        _viewItems[position].transform.localPosition = position;
    }

    private void OnBagRemovingItem(ItemBase item)
    {
    //    _viewItems.Remove();
    }
}
