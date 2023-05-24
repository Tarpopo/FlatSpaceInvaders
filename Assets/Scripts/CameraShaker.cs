using DG.Tweening;
using UnityEngine;

public static class CameraShaker
{
    public static void DoEasyShake()
    {
        Helpers.Camera.transform.DOShakePosition(0.2f, Vector3.one * 0.2f).onComplete = SetZeroVector;
    }

    public static void DoMiddleShake()
    {
        Helpers.Camera.transform.DOShakePosition(0.25f, Vector3.one * 0.3f).onComplete = SetZeroVector;
    }

    public static void DoHardShake()
    {
        Helpers.Camera.transform.DOShakePosition(0.4f, Vector3.one * 0.5f).onComplete = SetZeroVector;
    }

    private static void SetZeroVector() => Helpers.Camera.transform.position = Vector3.zero.WithZ(-1);
}