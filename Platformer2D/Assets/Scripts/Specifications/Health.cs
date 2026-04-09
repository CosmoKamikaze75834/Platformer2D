using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _min = 0;

    [field: SerializeField] public int Current { get; private set; }
    [field: SerializeField] public int Max { get; private set; } = 100;

    private bool _isDead = false;

    public event Action DamageReceived;
    public event Action Died;
    public event Action HealthChanged;

    private void Start()
    {
        Current = Max;
        HealthChanged?.Invoke();
    }

    public void Reduce(int damage)
    {
        if (_isDead)
            return;

        if (damage <= 0) 
            return;

        Current -= damage;

        LimitValues();

        HealthChanged?.Invoke();

        ProcessState();
    }

    private void ProcessState()
    {
        if (Current <= _min)
        {
            Current = _min;
            _isDead = true;
            Die();
            return;
        }

        DamageReceived?.Invoke();
    }

    private void Die()
    {
        Died?.Invoke();
    }

    public void Increase(int amount)
    {
        if (amount <= 0) return;

        Current += amount;

        LimitValues();

        HealthChanged?.Invoke();
    }

    private void LimitValues()
    {
        Current = Mathf.Clamp(Current, _min, Max);
    }
}