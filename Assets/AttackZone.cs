using System.Collections.Generic;
using UnityEngine;

public class AttackZone : MonoBehaviour
{
    private List<IDamageble> _targets;

    public List<IDamageble> Targets => _targets;

    private void Awake()
    {
        _targets = new List<IDamageble>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageble damageble;
        if (other.TryGetComponent<IDamageble>(out damageble))
            _targets.Add(damageble);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IDamageble damageble;
        if (other.TryGetComponent<IDamageble>(out damageble))
            _targets.Remove(damageble);
    }
}
