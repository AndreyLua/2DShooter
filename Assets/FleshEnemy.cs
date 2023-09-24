using UnityEngine;

public class FleshEnemy : EnemyBase
{
    [SerializeField] private HealthView _healthView;

    private Health _health;

    private void Awake()
    {
        _health = new Health(100,100);
        _health.Died += OnDied;
        _healthView.Init(_health);
    }

    public override void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnDied()
    {
        Debug.Log("fdlkfkjdsf");
        Destroy(gameObject);
    }
}
