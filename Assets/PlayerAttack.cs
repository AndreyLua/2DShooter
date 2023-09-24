using DG.Tweening;
using System;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private TMPHoldButton _button;
    [SerializeField] private BulletFactory _bulletFactory;

    private IWeaponAttack _attacker;
    private bool _canAttack = true;
    private bool _isAttack = false;

    public event Action<Vector2> PlayerAttacking;

    private void Awake()
    {
        _attacker = gameObject.GetComponent<IWeaponAttack>();
        _button.Hold += ChangeStateAttack;
    }

    private void Update()
    {
        if (_isAttack)
            Attack();
    }

    private void ChangeStateAttack(bool isAttack)
    {
        _isAttack = isAttack;
    }

    private void Attack()
    {
        if (_attacker.Zone.Targets.Count>0)
        {
            if (_canAttack)
            {
                IDamageble nearestTarget = GetNearestTarget();

                PlayerAttacking?.Invoke(nearestTarget.Transform.position);

                Vector2 direction = (nearestTarget.Transform.position - _attacker.Weapon.FirePoint.position).normalized;

                _bulletFactory.Create(_attacker.Weapon.FirePoint.position, direction, _attacker.Damage,_attacker);
                _canAttack = false;
                DOTween.Sequence().AppendInterval(_attacker.Rate).AppendCallback(() => _canAttack = true);
            }
        }
    }

    private IDamageble GetNearestTarget()
    {
        IDamageble nearestTarget = _attacker.Zone.Targets[0];

        for (int i =1; i < _attacker.Zone.Targets.Count; i++)
        { 
            if (Vector3.Distance(_attacker.Zone.Targets[i].Transform.position,gameObject.transform.position) < 
                Vector3.Distance(nearestTarget.Transform.position, gameObject.transform.position))
            {
                nearestTarget = _attacker.Zone.Targets[i];
            } 
        }
        return nearestTarget;
    }
}
