using System;
using System.Collections.Generic;
using UnityEngine;

public class BagView : MonoBehaviour
{
    [SerializeField] private Bag _bag;
    [SerializeField] private ItemView _itemView;
    [SerializeField] private RectTransform _transformParent;
    [SerializeField] private Vector2 _startFreePosition;
    [SerializeField] private TMPButton _button;

    private Queue<Vector2> _freePositions;
    private Dictionary<Vector2, ItemView> _viewItems;
    private Dictionary<ItemType, Vector2> _typeWithPositionItems;

    public event Action<ItemView> AddedItemView;
    public event Action<ItemView> RemovingItemView;

    private void Awake()
    {
        _button.Clicked += OpenAndCloseBag;

        _freePositions = new Queue<Vector2>();

        for (int i = 0; i < 10; i++)
            _freePositions.Enqueue(_startFreePosition + new Vector2(i* 120, 0));

        _viewItems = new Dictionary<Vector2, ItemView>();
        _typeWithPositionItems = new Dictionary<ItemType, Vector2>();

        _bag.BagAddedItem += OnBagAddedItem;
        _bag.BagRemovingItem += OnBagRemovingItem;

        gameObject.SetActive(false);
    }

    private void OpenAndCloseBag()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    private void OnBagAddedItem(ItemBase item)
    {
        if (_typeWithPositionItems.ContainsKey(item.Type))
        {
            Vector2 position = _typeWithPositionItems[item.Type];
            _viewItems[position].AddedCount();
        }
        else
        {
            Vector2 position = _freePositions.Dequeue();
            _viewItems[position] = Instantiate<ItemView>(_itemView);
            _viewItems[position].Init(item.Type, item.Sprite);
            _viewItems[position].transform.SetParent(_transformParent);
            _viewItems[position].transform.localPosition = position;
            _typeWithPositionItems[item.Type] = position;
            AddedItemView?.Invoke(_viewItems[position]);
        }
    }

    private void OnBagRemovingItem(ItemBase item)
    {
         RemovingItemView?.Invoke(_viewItems[(_typeWithPositionItems[item.Type])]);
        _freePositions.Enqueue(_typeWithPositionItems[item.Type]);
        _viewItems.Remove(_typeWithPositionItems[item.Type]);
        _typeWithPositionItems.Remove(item.Type);
    }
}
