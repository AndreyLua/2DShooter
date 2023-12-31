﻿using System;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IDamageble
{
    public Transform Transform => gameObject.transform;

    public abstract void TakeDamage(float damage);

    public event Action<EnemyBase> Died;

    public void SendDiedEvent()
    {
        Died?.Invoke(this);
    }
}