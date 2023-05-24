using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private float _shootDelay;
    private Timer _timer;

    private void Awake() => _timer = new Timer();

    private void Start() => _timer.StartTimer(Random.Range(_shootDelay / 2, _shootDelay), TryShoot);

    private void Update() => _timer.UpdateTimer();

    private void TryShoot()
    {
        var enemies = _enemies.Where(enemy => enemy.IsActive);
        var enumerable = enemies as Enemy[] ?? enemies.ToArray();
        _timer.StartTimer(Random.Range(_shootDelay / 2, _shootDelay), TryShoot);
        if (enumerable.Length <= 0) return;
        enumerable.GetRandElement().Shoot();
    }
}