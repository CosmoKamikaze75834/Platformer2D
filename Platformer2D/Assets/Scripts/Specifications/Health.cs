using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _minHealth = 0;
    [SerializeField] private int _maxHealth = 100;

    private bool _isDead = false;

    public event Action DamageReceived;
    public event Action Died;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (_isDead)
            return;

        _currentHealth -= damage;

        ProcessState();
    }

    private void ProcessState()
    {
        if (_currentHealth <= _minHealth)
        {
            _currentHealth = _minHealth;
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

    public void Heal(int amount)
    {
        _currentHealth += amount;

        if (_currentHealth >= _maxHealth)
            _currentHealth = _maxHealth;
    }
}