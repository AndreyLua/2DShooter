using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private Transform[] _handPoints;

    public Transform[] HandPoints => _handPoints;
    
    public abstract float Damage {get;}
    public abstract float Rate { get; }
    public abstract WeaponHandType HandType { get; }
}

