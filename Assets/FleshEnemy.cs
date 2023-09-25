using DG.Tweening;
using System;
using UnityEngine;

public class FleshEnemy : EnemyBase, IAttack, IMoveble
{
    [SerializeField] private HealthView _healthView;
    [SerializeField] private EnemyAttackZone _attackZone;

    private Rigidbody2D _rigidbody;
    private Health _health;
    private bool _canAttack = true;
    private float _distanceAttack = 2; 

    public float Damage => 20;
    public float Rate => 1;
    public AttackZone Zone => _attackZone;

    public float Speed => 2;
    public Rigidbody2D Rigidbody => _rigidbody;

    public event Action Died;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        _health = new Health(100,100);
        _health.Died += OnDied;
        _healthView.Init(_health);
    }

    private void Update()
    {
        if (_attackZone.Targets.Count > 0)
        {
            if (Vector3.Distance(_attackZone.Targets[0].Transform.position, gameObject.transform.position) <= _distanceAttack)
                AttackTarget();
            else
                MoveToTarget();
        }
    }

    private void MoveToTarget()
    {
        Vector2 direction = _attackZone.Targets[0].Transform.position - gameObject.transform.position;
        _rigidbody.transform.position += (Vector3)direction.normalized * Speed * Time.deltaTime;
    }

    private void AttackTarget()
    {
        if (_canAttack)
        {
            _attackZone.Targets[0].TakeDamage(Damage);
            _canAttack = false;
            DOTween.Sequence().AppendInterval(Rate).AppendCallback(() => _canAttack = true);
        }
    }


    public override void TakeDamage(float damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnDied()
    {
        Died?.Invoke();
        gameObject.SetActive(false);
    }
}


