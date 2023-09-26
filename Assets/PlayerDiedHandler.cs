using UnityEngine;

public class PlayerDiedHandler : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player.Died += OnDied;
        gameObject.SetActive(false);
    }

    private void OnDied()
    {
        gameObject.SetActive(true);
    }
}
