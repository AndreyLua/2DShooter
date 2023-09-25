using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private EnemyBase _enemy;
    [SerializeField] private EnemyStorage _storage;

    public EnemyBase Create(Vector2 position)
    {
        EnemyBase enemy = Instantiate<EnemyBase>(_enemy);

        enemy.transform.position = position;

        _storage.Add(enemy);
        return enemy;
    }
}