using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _startSpwanDelay;
    [SerializeField] private float _spwanDelay;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private OnPlayerDead _onPlayerDead;
    [SerializeField] private OnEnemySpawn _onEnemySpawn;
    [SerializeField] private OnAllEnemyEnd _onAllEnemyEnd;

    private void Start() => SpawnEnemy();

    private void OnEnable()
    {
        _onPlayerDead.Subscribe(SpawnEnemy);
        _onAllEnemyEnd.Subscribe(SpawnEnemy);
    }

    private void OnDisable()
    {
        _onPlayerDead.Unsubscribe(SpawnEnemy);
        _onAllEnemyEnd.Unsubscribe(SpawnEnemy);
    }

    private void SpawnEnemy()
    {
        foreach (var enemy in _enemies) enemy.gameObject.Disable();
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        yield return Helpers.GetWait(_startSpwanDelay);
        foreach (var enemy in _enemies)
        {
            enemy.gameObject.Enable();
            _onEnemySpawn.Invoke();
            yield return Helpers.GetWait(_spwanDelay);
        }
    }
}