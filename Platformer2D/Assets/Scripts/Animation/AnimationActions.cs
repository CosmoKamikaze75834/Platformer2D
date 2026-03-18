using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationActions : MonoBehaviour
{
    private static readonly int Speed = Animator.StringToHash(nameof(Speed));
    private static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
    private static readonly int Hit = Animator.StringToHash(nameof(Hit));
    private static readonly int IsDead = Animator.StringToHash(nameof(IsDead));
    private static readonly int Hurt = Animator.StringToHash(nameof(Hurt));

    private Animator _animator;

    public Animator Animator => _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void EstablishSpeed(float movement)
    {
        _animator.SetFloat(Speed, Mathf.Abs(movement));
    }

    public void TriggerAttack()
    {
        _animator.SetTrigger(Hit);
    }

    public void EstablishJump(bool isJumping)
    {
        _animator.SetBool(IsJump, isJumping);
    }

    public bool GetDeadState()
    {
        return _animator.GetBool(IsDead);
    }

    public void TriggerHurt()
    {
        _animator.SetTrigger(Hurt);
    }

    public void EstablishDead()
    {
        _animator.SetBool(IsDead, true);
    }

    public bool GetJumpState()
    {
        return _animator.GetBool(IsJump);
    }
}