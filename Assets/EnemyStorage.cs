using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStorage : MonoBehaviour
{
    private List<EnemyBase> _enemies;

    public event Action<EnemyBase> RemovedEnemy;

    private void Awake()
    {
        _enemies = new List<EnemyBase>();
    }

    public void Add(EnemyBase enemy)
    {
        _enemies.Add(enemy);
    }

    public void Remove(EnemyBase enemy)
    {
        RemovedEnemy?.Invoke(enemy);
        _enemies.Remove(enemy);
    }
}
