using DG.Tweening;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private TMPButton _button;

    [SerializeField] private BulletFactory _bulletFactory;

    private IAttack _attacker;
    private bool _canAttack = true;


    private void Awake()
    {
        _attacker = gameObject.GetComponent<IAttack>();
        _button.Clicked += Attack;
    }

    private void Attack()
    {
        if (_attacker.Zone.Targets.Count>0)
        {
            if (_canAttack)
            {
                IDamageble nearestTarget = GetNearestTarget();

                Vector2 direction = nearestTarget.Transform.position - gameObject.transform.position;

                _bulletFactory.Create(gameObject.transform.position, direction, _attacker.Damage,_attacker);
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
