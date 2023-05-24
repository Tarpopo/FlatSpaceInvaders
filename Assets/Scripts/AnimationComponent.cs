using System;
using UnityEngine;

[Serializable]
public class AnimationComponent
{
    [SerializeField] private Animator _animator;
    public void PlayAnimation(Enum animationType) => _animator.Play(animationType.ToString());
    public void PlayAnimation(string animationName) => _animator.Play(animationName, 0);
    public void PlayAnimation(AnimationClip clip) => _animator.Play(clip.name);
}

public enum ParticlesAnimations
{
    Empty,
    Explosion,
    Circles
}