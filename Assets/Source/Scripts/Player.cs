using UnityEngine;

public class Player : MonoBehaviour, IMoveble, IAttack
{
    [SerializeField] private AttackZone _attackZone;

    [SerializeField] private WeaponBase _weaponBase;

    private Rigidbody2D _rigidbody;

    public float Speed => 4;

    public Rigidbody2D Rigidbody => _rigidbody;

    public float Damage => _weaponBase.Damage;

    public float Rate => _weaponBase.Rate;

    public AttackZone Zone => _attackZone;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
}
