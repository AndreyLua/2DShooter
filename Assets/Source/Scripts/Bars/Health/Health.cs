using System;

public class Health
{
    private BarStorage _barStorage;

    public event Action Died;
    public event Action Changed;

    public Health(float value, float maxValue)
    {
        _barStorage = new BarStorage(value, maxValue);
        _barStorage.ChangeValue += Changed;
        _barStorage.StorageEmpty += Died;
    }

    public void TakeDamage(float value)
    {
        _barStorage.Take(value);
    }

    public void Heal(float value)
    {
        _barStorage.Add(value);
    }
}
