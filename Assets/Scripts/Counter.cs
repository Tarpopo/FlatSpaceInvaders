using System;

public class Counter
{
    private Action _onCountEnded;
    private int _value;

    public void StartCounterValue(int value, Action onEnded)
    {
        _onCountEnded = onEnded;
        _value = value;
    }

    public void ReduceValue()
    {
        if (_value <= 0) return;
        _value--;
        if (_value <= 0) _onCountEnded?.Invoke();
    }
}