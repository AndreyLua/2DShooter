using UnityEngine;

public class CommonItem : ItemBase
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ICollector collector;
        if (other.gameObject.TryGetComponent<ICollector>(out collector))
        {
            collector.CollectItem(this);
            Destroy(gameObject);
        }
    }
}
