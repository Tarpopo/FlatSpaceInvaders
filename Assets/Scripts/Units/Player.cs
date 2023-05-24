using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private Weapon _weapon;
    private IMove _rigidbodyMove;

    public void TakeDamage(int damage)
    {
        _playerData.OnPlayerTakeDamage.Invoke();
        CameraShaker.DoHardShake();
        _playerData.ParticlesPool.Get().SetParticle(transform.position, ParticlesAnimations.Explosion);
        gameObject.Disable();
    }

    private void Awake() => _rigidbodyMove = new RigidbodyMove(GetComponent<Rigidbody2D>());

    private void OnEnable()
    {
        _playerInput.OnMove += Move;
        _playerInput.OnShoot += Shoot;
        _playerData.OnPlayerDead.Subscribe(OnDead);
        _playerData.ParticlesPool.Get().SetParticle(transform.position, ParticlesAnimations.Circles);
    }

    private void OnDisable()
    {
        _playerInput.OnMove -= Move;
        _playerInput.OnShoot -= Shoot;
        _playerData.OnPlayerDead.Unsubscribe(OnDead);
    }

    private void Move(Vector2 moveDirection) => _rigidbodyMove.Move(moveDirection, _playerData.MoveSpeed);

    private void Shoot() => _weapon.TryShoot();

    private void OnDead() =>
        _playerData.ParticlesPool.Get().SetParticle(transform.position, ParticlesAnimations.Circles);
}