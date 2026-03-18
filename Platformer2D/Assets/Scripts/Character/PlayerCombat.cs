using System;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] private PlayerAttackDetector _attackDetector;
    [SerializeField] private PlayerAttackAnimation _attackAnimation;
    [SerializeField] private InputService _inputService;

    private bool _isAttack;
    private bool _isDamageDown;

    private void Update()
    {
        if (_inputService.AttackPressed && _isAttack == false)
        {
            StartAttack();
        }

        if (_isAttack)
        {
            ApplyDamageOnce();
            CheckAttackEnd();
        }
    }

    private void StartAttack()
    {
        _attackAnimation.StartAnimationAttack();
        _isAttack = true;
        _isDamageDown = false;
        _attackAnimation.ResetState();
    }

    private void ApplyDamageOnce()
    {
        if (_isDamageDown)
            return;

        bool isDamageApplied = _attackDetector.Attack();

        if (isDamageApplied)
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