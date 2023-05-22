using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private MoveSettings[] _moveSettings;
    [SerializeField] private float _moveValue;
    [SerializeField] private float _moveDelay;
    private int _currentMoveIndex = -1;
    private Timer _timer;
    private Counter _counter;

    private void Awake()
    {
        _timer = new Timer();
        _counter = new Counter();
        SetNewPattern();
        _timer.StartTimer(_moveDelay, Move);
    }

    private void Update() => _timer.UpdateTimer();

    private void Move()
    {
        transform.Translate(_moveSettings[_currentMoveIndex].MoveDirection * _moveValue);
        _counter.ReduceValue();
        _timer.StartTimer(_moveDelay, Move);
    }

    private void SetNewPattern()
    {
        _currentMoveIndex = _moveSettings.GetNextIndex(_currentMoveIndex);
        _counter.StartCounterValue(_moveSettings[_currentMoveIndex].StepCount, SetNewPattern);
    }
}

[Serializable]
public struct MoveSettings
{
    public Vector2 MoveDirection => _moveDirection;
    public int StepCount => _stepCount;
    [SerializeField] private Vector2 _moveDirection;
    [SerializeField] private int _stepCount;
}