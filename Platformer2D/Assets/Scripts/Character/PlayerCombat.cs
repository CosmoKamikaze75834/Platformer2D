using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerAttackDetector _attackDetector;
    [SerializeField] private PlayerAttackAnimation _attackAnimation;
    [SerializeField] private InputService _inputService;
    [SerializeField] private AnimationActions _animаtion;

    private bool _isAttack;//атаковываем?
    private bool _isDamageDown;//урон уже был нанесён?

    private void Update()
    {
        if (_inputService.AttackPressed && _isAttack == false)
        {
            StartAttack();
        }

        if (_isAttack)//атакуем
        {
            TryDealDamage();
            CheckAttackEnd();
        }
    }

    private void StartAttack()
    {
        _animаtion.TriggerAttack();//запускаем анимацию атаки
        _isAttack = true;
        _isDamageDown = false;
        _attackAnimation.ResetState();
    }

    private void TryDealDamage()
    {
        if (_isDamageDown)
            return;

        bool damageApplied = _attackDetector.Attack();
        Debug.Log("Провели атаку");

        if (damageApplied)
            _isDamageDown = true;
    }

    private void CheckAttackEnd()
    {
        if (_attackAnimation.IsAttackFinished())
        {
            _isAttack = false;
        }
    }
}