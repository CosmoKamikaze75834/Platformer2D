using UnityEngine;

public class PlayerAttackAnimation : MonoBehaviour
{
    private static string StateHit = "Hit";

    [SerializeField] private AnimationActions _animàtion;

    private bool _isHitState;
    private int _index = 0;

    public void ResetState()
    {
        _isHitState = false;
    }

    public bool IsAttackFinished()
    {
        AnimatorStateInfo stateInfo = _animàtion.Animator.GetCurrentAnimatorStateInfo(_index);

        if (stateInfo.IsName(StateHit))
        {
            _isHitState = true;
            return false;
        }

        if (_isHitState)
        {
            _isHitState = false;
            return true;
        }

        return false;
    }

    public void StartAnimationAttack()
    {
        _animàtion.TriggerAttack();
    }
}