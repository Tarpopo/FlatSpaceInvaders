using System;
using System.Collections;
using UnityEngine;

public class PlayerReseter : MonoBehaviour
{
    [SerializeField] private float _resetDelay = 1;
    [SerializeField] private Player _player;
    [SerializeField] private OnPlayerTakeDamage _onPlayerDead;

    private void Start() => ResetPlayer();

    private void OnEnable() => _onPlayerDead.Subscribe(ResetPlayer);

    private void OnDisable() => _onPlayerDead.Unsubscribe(ResetPlayer);

    private void ResetPlayer() => StartCoroutine(ResetRoutine());

    private IEnumerator ResetRoutine()
    {
        yield return Helpers.GetWait(_resetDelay);
        _player.gameObject.Enable();
    }
}