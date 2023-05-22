using System;
using NaughtyAttributes;
using UnityEngine;

[Serializable]
public class EnemyWeapon
{
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private Vector2 _shootDirection;
    [SerializeField, Tag] private string _ignoreTag;

    public void Shoot()
    {
        var bullet = _bulletPool.Get();
        bullet.StartMove(_shootPoint.position, _shootDirection, _ignoreTag);
    }
}