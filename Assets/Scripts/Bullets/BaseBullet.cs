using System.Linq;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _bulletLlifeTime;
    protected string[] _ignoreTags;

    private RigidbodyMove _rigidbodyMove;
    private Vector2 _moveDirection;
    private Timer _timer;

    public void StartMove(Vector2 startMovePosition, Vector2 moveDirection, string[] ignoreTags)
    {
        transform.position = startMovePosition;
        _moveDirection = moveDirection;
        _timer.StartTimer(_bulletLlifeTime, DisableBullet);
        _ignoreTags = ignoreTags;
    }

    private void Awake()
    {
        _rigidbodyMove = new RigidbodyMove(GetComponent<Rigidbody2D>());
        _timer = new Timer();
    }

    private void Update()
    {
        _rigidbodyMove.Move(_moveDirection, _moveSpeed);
        _timer.UpdateTimer();
    }

    protected virtual void OnDisable() => _rigidbodyMove.StopMove();

    protected virtual void OnTriggerEnter2D(Collider2D col)
    {
        if (_ignoreTags.Any(ignoreTag => col.tag.Equals(ignoreTag))) return;
        if (col.TryGetComponent<IDamageable>(out var damageable)) damageable.TakeDamage(1);
        DisableBullet();
    }

    protected abstract void DisableBullet();
}