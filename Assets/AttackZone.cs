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

    protected virtual bool MaskFunction(Collider2D other)
    {
        return true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageble damageble;
        if (other.TryGetComponent<IDamageble>(out damageble) && MaskFunction(other))
            _targets.Add(damageble);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IDamageble damageble;
        if (other.TryGetComponent<IDamageble>(out damageble) && MaskFunction(other))
            _targets.Remove(damageble);
    }
}
