using UnityEngine;
using DG.Tweening;

public class BarView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _bar;
    [SerializeField] private SpriteRenderer _dynamicBar;

    [SerializeField] private float _updateValueDuration = 0.4f;
    [SerializeField] private float _updateValueDynamicRatio = 2;

    private BarStorage _storage;

    public void Init(BarStorage storage)
    {
        _storage = storage;
        storage.ChangeValue += UpdateBar;
    }

    public virtual void UpdateBar()
    {
        float storageRatio = _storage.Value / _storage.MaxValue;
        _bar.transform.DOScaleX(storageRatio, _updateValueDuration);
        _dynamicBar.transform.DOScaleX(storageRatio, _updateValueDuration/2);
    }
}
