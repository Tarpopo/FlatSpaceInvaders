using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IDamageable
{
    public event Action OnTakeDamage;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Weapon _weapon;
    private IMove _rigidbodyMove;

    private void Awake() => _rigidbodyMove = new RigidbodyMove(GetComponent<Rigidbody2D>());


    private void OnEnable()
    {
        _playerInput.OnMove += Move;
        _playerInput.OnShoot += Shoot;
    }

    private void OnDisable()
    {
        _playerInput.OnMove -= Move;
        _playerInput.OnShoot -= Shoot;
    }

    private void Move(Vector2 moveDirection) => _rigidbodyMove.Move(moveDirection, _playerData.MoveSpeed);

    private void Shoot() => _weapon.TryShoot();

    public void TakeDamage(int damage)
    {
        OnTakeDamage?.Invoke();
        _playerData.OnPlayerTakeDamage.Invoke();
        print("im take damage");
    }
}