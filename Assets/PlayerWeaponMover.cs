using UnityEngine;

public class PlayerWeaponMover : MonoBehaviour
{
    private WeaponBase _weapon;
    [SerializeField] private PlayerAttack _playerAttack;

    private void Awake()
    {
        _weapon = gameObject.GetComponent<WeaponBase>();
        _playerAttack.PlayerAttacking += OnPlayerAttacked;
    }
    
    private void OnPlayerAttacked(Vector2 target)
    {
        Vector2 direction = target - (Vector2)_weapon.FirePoint.position;

        float angleRotation = -Mathf.Atan2(direction.x, direction.y) * 180 / Mathf.PI + 90;
        _weapon.gameObject.transform.rotation = Quaternion.Euler(0, 0, angleRotation);
    }
}
