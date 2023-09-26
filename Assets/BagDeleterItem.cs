using UnityEngine;

public class BagDeleterItem : MonoBehaviour
{
    [SerializeField] private BagView _bagView;
    [SerializeField] private TMPButton _deleteButton;

    private void Awake()
    {
        _bagView.AddedItemView += OnAddedItemView;
        _bagView.RemovingItemView += OnRemovingItemView;
    }

    private void OnAddedItemView(ItemView itemView)
    {
        itemView.ShowDeleteButton += ShowDeleteButton;
    }

    private void OnRemovingItemView(ItemView itemView)
    {
        itemView.ShowDeleteButton -= ShowDeleteButton;
    }

    private void ShowDeleteButton()
    {

    }
}
