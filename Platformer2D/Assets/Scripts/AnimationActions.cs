using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationActions : MonoBehaviour
{
    private static readonly int Speed = Animator.StringToHash(nameof(Speed));
    private static readonly int IsJump = Animator.StringToHash(nameof(IsJump));

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void EstablishSpeed(float movement)
    {
        _animator.SetFloat(Speed, Mathf.Abs(movement));
    }

    public void EstablishJump(bool isJumping)
    {
        _animator.SetBool(IsJump, isJumping);
    }

    public bool GetJumpState()
    {
        return _animator.GetBool(IsJump);
    }
}