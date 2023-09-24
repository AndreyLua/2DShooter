using UnityEngine;

public interface IAttack
{
    public float Damage { get; }
    public float Rate { get; }
    public AttackZone Zone { get; }
}
