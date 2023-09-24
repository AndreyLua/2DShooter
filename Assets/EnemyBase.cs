using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageble
{
    public Transform Transform => gameObject.transform;

    public abstract void TakeDamage(float damage);
}