using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] private Transform[] _handPoints;
    [SerializeField] private Transform _firePoint;

    public Transform[] HandPoints => _handPoints;
    public Transform FirePoint => _firePoint;

    public abstract float Damage {get;}
    public abstract float Rate { get; }
    public abstract WeaponHandType HandType { get; }
}

