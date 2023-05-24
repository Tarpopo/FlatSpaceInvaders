using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public bool IsActive { get; private set; }
    public EnemyType EnemyType => _enemyType;
    [SerializeField] private EnemyWeapon _enemyWeapon;
    [SerializeField] private OnEnemyDead _onEnemyDead;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private ParticlesPool _particlesPool;
    [SerializeField] private EnemyType _enemyType;
    public event Action OnTakeDamage;

    public void TakeDamage(int damage)
    {
        _onEnemyDead.Invoke(this);
        CameraShaker.DoEasyShake();
        _particlesPool.Get().SetParticle(transform.position, ParticlesAnimations.Explosion);
        _enemyPool.Return(this);
    }

    public void Shoot() => _enemyWeapon.Shoot(transform);

    private void OnEnable() => IsActive = true;

    private void OnDisable() => IsActive = false;
}

public enum EnemyType
{
    Easy,
    Middle,
    Hard
}