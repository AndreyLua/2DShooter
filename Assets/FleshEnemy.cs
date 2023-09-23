using UnityEngine;

public class FleshEnemy : EnemyBase
{
    public override void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}

public abstract class EnemyBase : MonoBehaviour, IDamageble
{
    public Transform Transform => gameObject.transform;

    public abstract void TakeDamage(float damage);
}