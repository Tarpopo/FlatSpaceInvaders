using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float _scaleAnimationDuration;
    [SerializeField] private float _scaleAnimation;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootDelay;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Vector2 _shootDirection;
    [SerializeField, Tag] private string[] _ignoreTags;
    private readonly Timer _timer = new Timer();

    public void TryShoot()
    {
        if (_timer.IsTick) return;
        _timer.StartTimer(_shootDelay, null);
        var bullet = _bulletPool.Get();
        bullet.StartMove(_shootPoint.position, _shootDirection, _ignoreTags);
        transform.DOPunchScale(transform.localScale * _scaleAnimation, _scaleAnimationDuration);
        CameraShaker.DoEasyShake();
    }

    private void Start() => _bulletPool.Load();

    private void Update() => _timer.UpdateTimer();
}