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

    public event Action ShowDeleteButton;   

    private void Awake()
    {
        _button = gameObject.GetComponent<TMPButton>();
        _image = gameObject.GetComponentInChildren<Image>();
        _text.text = "1";
        _button.Clicked += OnImageClicked;
    }

    private void OnImageClicked()
    {
        ShowDeleteButton?.Invoke();
    }

    public void Init(ItemType type, Sprite sprite)
    {
        SetSprite(sprite);
        _type = type;
    }

    public void AddedCount()
    {
        _text.text = (int.Parse(_text.text) + 1).ToString();
    }

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
}
