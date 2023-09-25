using UnityEngine;

public class LevelEnemyCreator : MonoBehaviour
{
    [SerializeField] private EnemyFactory _enemyFactory;

    private void Start()
    {
        _enemyFactory.Create(new Vector2(2.67f, -1.70621f));
        _enemyFactory.Create(new Vector2(2.67f, -3.70621f));
        _enemyFactory.Create(new Vector2(5.67f, -1.70621f));
    }
}
