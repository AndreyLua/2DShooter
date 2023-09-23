using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 _direction;
    private float _damage;
    private float _speed = 10;
    private IAttack _owner;

    public void Init(Vector2 direction, float damage, IAttack owner)
    {
        _direction = direction.normalized;
        _damage = damage;
        _owner = owner;
    }

    private void Update()
    {
        gameObject.transform.position += (Vector3)_direction * _speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        IDamageble damageble;
        if (collision.gameObject.TryGetComponent<IDamageble>(out damageble) && _owner != damageble)
        {
            damageble.TakeDamage(_damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}