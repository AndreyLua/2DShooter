using UnityEngine;

public class EnemyItemDroper : MonoBehaviour
{
    [SerializeField] private EnemyStorage _enemyStorage;
    [SerializeField] private ItemFactory _itemFactory;

    private void Awake()
    {
        _enemyStorage.AddedEnemy += OnAddedEnemy;
        _enemyStorage.RemovedEnemy += OnRemovedEnemy;
    }

    private void OnAddedEnemy(EnemyBase enemy)
    {
        enemy.Died += DropItem;
    }

    private void OnRemovedEnemy(EnemyBase enemy)
    {
        enemy.Died -= DropItem;
    }

    private void DropItem(EnemyBase enemy)
    {
        _itemFactory.CreateRandomItem<CommonItem>(enemy.transform.position);
    }
}
