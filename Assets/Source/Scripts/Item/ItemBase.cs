using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    private SpriteRenderer _spriteRender;
    private ItemType _itemType;

    public Sprite Sprite => _spriteRender.sprite;
    public ItemType Type => _itemType;

    private void Awake()
    {
        _spriteRender = gameObject.GetComponent<SpriteRenderer>();
    }

    private void SetSprite(Sprite sprite)
    {
        _spriteRender.sprite = sprite;
    }

    public void Init(ItemType type, Sprite sprite)
    {
        SetSprite(sprite);
        _itemType = type;
    }
}
