using System.Collections.Generic;
using UnityEngine;

public class BulletStorage : MonoBehaviour
{
    private List<Bullet> _bullets;

    private void Awake()
    {
        _bullets = new List<Bullet>();
    }

    public void Add(Bullet bullet)
    {
        _bullets.Add(bullet);
    }

    public void Remove(Bullet bullet)
    {
        _bullets.Remove(bullet);
    }
}

