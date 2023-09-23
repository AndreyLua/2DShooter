using UnityEngine;

public class Player : MonoBehaviour, IMoveble
{
    private Rigidbody2D _rigidbody;

    public float Speed => 4;

    public Rigidbody2D Rigidbody => _rigidbody;

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
}
