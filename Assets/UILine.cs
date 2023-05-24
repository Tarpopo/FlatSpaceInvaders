using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

public class UILine : MonoBehaviour
{
    [SerializeField] private float _hideDelay;
    [SerializeField] private float _animationDuration;
    [SerializeField] private RectTransform _rectTransform;
    [SerializeField] private Vector2 _startValue;
    [SerializeField] private Vector2 _endValue;
    private Tween _tween;

    [Button()]
    public void Show()
    {
        if (_tween == null) SetTween();
        _tween.PlayForward();
    }

    [Button()]
    public void Hide()
    {
        StartCoroutine(_hideDelay.WaitRoutine(() => _tween.PlayBackwards()));
    }

    private void Start() => _rectTransform.sizeDelta = _startValue;

    private void SetTween()
    {
        _tween = _rectTransform.DOSizeDelta(_endValue, _animationDuration);
        _tween.onComplete = Hide;
        _tween.SetAutoKill(false);
    }
}