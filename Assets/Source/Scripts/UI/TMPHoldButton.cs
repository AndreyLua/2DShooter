using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TMPHoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Button _screenButton;
    private TextMeshProUGUI _text;

    public string Text => _text.text;

    public event Action<bool> Hold;

    private void Awake()
    {
        _text = gameObject.GetComponentInChildren<TextMeshProUGUI>();
        _screenButton = gameObject.GetComponent<Button>();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Hold?.Invoke(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Hold?.Invoke(true);
    }
}