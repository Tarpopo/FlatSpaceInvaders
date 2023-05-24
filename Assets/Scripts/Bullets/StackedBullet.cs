using UnityEngine;

public class StackedBullet : BaseBullet
{
    [SerializeField] private BaseBulletPool _stackedBulletPool;
    [SerializeField] private BaseBulletPool _easyBulletPool;
    [SerializeField] private Transform[] _spawnPoints;

    protected override void DisableBullet()
    {
        _easyBulletPool.Get().StartMove(_spawnPoints[0].position,
            (_spawnPoints[0].position - transform.position).normalized, _ignoreTags);
        _easyBulletPool.Get().StartMove(_spawnPoints[1].position,
            (_spawnPoints[1].position - transform.position).normalized, _ignoreTags);
        _stackedBulletPool.Return(this);
    }
}