using UnityEngine;

public class BagDeleterItem : MonoBehaviour
{
    [SerializeField] private BagView _bagView;
    [SerializeField] private Bag _bag;
    [SerializeField] private TMPButton _deleteButton;

    private ItemView _targetView;

    private void Awake()
    {
        _bagView.AddedItemView += OnAddedItemView;
        _bagView.RemovingItemView += OnRemovingItemView;

        _deleteButton.Clicked += OnClicked;
    }

    private void OnAddedItemView(ItemView itemView)
    {
        itemView.ShowDeleteButton += ShowDeleteButton;
    }

    private void OnRemovingItemView(ItemView itemView)
    {
        itemView.ShowDeleteButton -= ShowDeleteButton;
    }

    private void ShowDeleteButton(ItemView view)
    {
        _targetView = view;
    }

    private void OnClicked()
    {
        if (_targetView!=null)
            _bag.RemoveItemOfType(_targetView.Type);
    }
}
