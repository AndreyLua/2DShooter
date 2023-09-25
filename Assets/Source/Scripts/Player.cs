using UnityEngine;

public class Player : MonoBehaviour, IMoveble, IWeaponAttack, IDamageble, ICollector
{
    [SerializeField] private AttackZone _attackZone;
    [SerializeField] private WeaponBase _weaponBase;
    [SerializeField] private HealthView _healthView;

    private Health _health;
    private Rigidbody2D _rigidbody;
    private Bag _bag;

    public float Speed => 4;
    public Rigidbody2D Rigidbody => _rigidbody;

    public float Damage => _weaponBase.Damage;
    public float Rate => _weaponBase.Rate;
    public AttackZone Zone => _attackZone;
    public WeaponBase Weapon => _weaponBase;

    public Transform Transform => _rigidbody.transform;

    private void Awake()
    {
        _health = new Health(100, 100);
        _healthView.Init(_health);
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    public void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    public void CollectItem(ItemBase item)
    {
        _bag.AddedItem(item);
    }
}
