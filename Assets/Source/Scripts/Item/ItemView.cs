using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Image _image;
    private ItemType _type;
    private TMPButton _button;
    private int _count;

    public int Count => _count;
    public ItemType Type => _type;
    public event Action<ItemView> ShowDeleteButton;   

    private void Awake()
    {
        _count = 1;
        _button = gameObject.GetComponent<TMPButton>();
        _image = gameObject.GetComponentInChildren<Image>();
        _text.text = _count.ToString();
        _button.Clicked += OnImageClicked;
    }

    private void OnImageClicked()
    {
        ShowDeleteButton?.Invoke(this);
    }

    public void Init(ItemType type, Sprite sprite)
    {
        SetSprite(sprite);
        _type = type;
    }

    public void AddedCount()
    {
        _count++;
        _text.text = _count.ToString();
    }

    public void RemoveCount()
    {
        _count--;
        _text.text = _count.ToString();
    }

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
