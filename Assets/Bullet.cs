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

        float angleRotation = -Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, angleRotation);
    }

    private void Update()
    {
        gameObject.transform.position += (Vector3)_direction * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageble damageble;
        if (other.gameObject.TryGetComponent<IDamageble>(out damageble) && _owner != damageble)
        {
            damageble.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }
}