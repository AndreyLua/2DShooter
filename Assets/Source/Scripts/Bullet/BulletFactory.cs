using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    public Bullet Create(Vector2 position, Vector2 direction, float damage, IAttack owner)
    {
        Bullet bullet = Instantiate<Bullet>(_bullet);

        bullet.transform.position = position;

        bullet.Init(direction, damage, owner);

        return bullet;
    }
}
