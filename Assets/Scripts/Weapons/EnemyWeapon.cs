using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

[Serializable]
public class EnemyWeapon
{
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private float _scaleAnimationDuration;
    [SerializeField] private float _scaleAnimation;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private BaseBulletPool _bulletPool;
    [SerializeField] private Vector2 _shootDirection;
    [SerializeField, Tag] private string[] _ignoreTags;

    public void Shoot(Transform transform)
    {
        var bullet = _bulletPool.Get();
        bullet.StartMove(_shootPoint.position, _shootDirection, _ignoreTags);
        transform.DOPunchScale(transform.localScale * _scaleAnimation, _scaleAnimationDuration);
        _renderer.DOColor(Color.red, _scaleAnimationDuration / 2).onComplete = SetBlackColor;
    }

    public void SetBlackColor() => _renderer.color = Color.black;
}