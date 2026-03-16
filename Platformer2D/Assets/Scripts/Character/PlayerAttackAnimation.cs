using UnityEngine;

public class PlayerAttackAnimation : MonoBehaviour
{
    [SerializeField] private AnimationActions _animаtion;



    private bool _isHitState;//анимация в состоянии удара?
    private int _index = 0;//базовый слой аниматора

    public void ResetState()
    {
        _isHitState = false;
    }

    public bool IsAttackFinished()
    {
        //какое сейчас состояние проигрывается
        AnimatorStateInfo stateInfo = _animаtion.Animator.GetCurrentAnimatorStateInfo(_index);

        //если состояние Hit
        if (stateInfo.IsName("Hit"))
        {
            _isHitState = true;
            return false;
        }

        //анимация проигралась
        if (_isHitState)
        {
            _isHitState = false;
            return true;
        }

        return false;
    }
}