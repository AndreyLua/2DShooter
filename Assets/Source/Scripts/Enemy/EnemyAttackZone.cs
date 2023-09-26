using UnityEngine;

public class EnemyAttackZone : AttackZone
{
    protected override bool MaskFunction(Collider2D other)
    {
        Player player; 
        return other.gameObject.TryGetComponent<Player>(out player);
    }
}