using System.Collections.Generic;
using UnityEngine;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] private GameObject[] _lives;
    [SerializeField] private OnPlayerTakeDamage _playerTakeDamage;
    [SerializeField] private OnPlayerDead _onPlayerDead;
    private readonly Stack<GameObject> _activeLives = new Stack<GameObject>(4);

    private void Start()
    {
        RestoreLives();
    }

    private void OnEnable() => _playerTakeDamage.Subscribe(ReduceLive);

    private void OnDisable() => _playerTakeDamage.Unsubscribe(ReduceLive);

    private void ReduceLive()
    {
        if (_activeLives.TryPop(out var live) == false) return;
        live.Disable();
        if (_activeLives.Count <= 0) _onPlayerDead.Invoke();
    }

    private void RestoreLives()
    {
        foreach (var live in _lives)
        {
            live.Enable();
            _activeLives.Push(live);
        }
    }
}