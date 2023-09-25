using UnityEngine;

public class PlayerHandMover : MonoBehaviour
{
    [SerializeField] private Transform _lefArm;
    [SerializeField] private Transform _rightArm;

    [SerializeField] private Transform _leftHand;
    [SerializeField] private Transform _rightHand;

    [SerializeField] private WeaponBase _weapon;
    [SerializeField] private PlayerAttack _playerAttack;

    private void Awake()
    {
        _playerAttack.PlayerAttacking += OnPlayerAttacking;
        SetStartPosition();
    }

    private void OnPlayerAttacking(Vector2 target)
    {
        SetStartPosition();
    }

    private void SetStartPosition()
    {
        switch (_weapon.HandType)
        {
            case WeaponHandType.One:
                break;
            case WeaponHandType.Two:
                SetHandPosition(_leftHand, _weapon.HandPoints[0]);
                SetHandPosition(_rightHand, _weapon.HandPoints[1]);
                break;
        }
    }

    private void MoveArm()
    {

    }

    private void SetHandPosition(Transform hand, Transform weaponHandPoint)
    {
        Vector2 offset = hand.position - weaponHandPoint.position;

        float angleRotation = -Mathf.Atan2(offset.x, offset.y)*180/Mathf.PI;

        hand.transform.rotation = Quaternion.Euler(0, 0,angleRotation);
    }
}
