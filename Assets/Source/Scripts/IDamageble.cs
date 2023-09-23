using UnityEngine;

public interface IDamageble
{
    public Transform Transform {get;}
    void TakeDamage(float damage);
}
