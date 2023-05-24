using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] private OnEnemyDead _onEnemyDead;
    [SerializeField] private OnEnemySpawn _onEnemySpawn;
    [SerializeField] private OnAllEnemyEnd _onAllEnemyEnd;
    [SerializeField] private OnPlayerDead _onPlayerDead;
    private int _enemyCount;

    private void OnEnable()
    {
        _onEnemyDead.Subscribe(ReduceCount);
        _onEnemySpawn.Subscribe(AddCount);
        _onPlayerDead.Subscribe(ResetCounter);
    }

    private void OnDisable()
    {
        _onEnemyDead.Unsubscribe(ReduceCount);
        _onEnemySpawn.Unsubscribe(AddCount);
        _onPlayerDead.Unsubscribe(ResetCounter);
    }

    private void ReduceCount(Enemy enemy)
    {
        if (_enemyCount <= 0) return;
        _enemyCount--;
        if (_enemyCount <= 0) _onAllEnemyEnd.Invoke();
    }

    private void ResetCounter() => _enemyCount = 0;
    private void AddCount() => _enemyCount++;
}