using System;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public EnemyType EnemyType => _enemyType;
    [SerializeField] private EnemyWeapon _enemyWeapon;
    [SerializeField] private OnEnemyDead _onEnemyDead;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private EnemyType _enemyType;
    public event Action OnTakeDamage;

    // private void Start()
    // {
    //     Shoot();
    // }

    public void TakeDamage(int damage)
    {
        _onEnemyDead.Invoke(this);
        _enemyPool.Return(this);
    }

    public void Shoot() => _enemyWeapon.Shoot();
}

public enum EnemyType
{
    Easy,
    Middle,
    Hard
}