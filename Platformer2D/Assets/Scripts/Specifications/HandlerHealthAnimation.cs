using UnityEngine;

public class HandlerHealthAnimation : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private AnimationActions _animation;

    private void OnEnable()
    {
        _health.DamageReceived += InformDamage;
        _health.Died += InformDeath;
    }

    private void OnDisable()
    {
        _health.DamageReceived -= InformDamage;
        _health.Died -= InformDeath;
    }

    private void InformDamage()
    {
        _animation.TriggerDefeat();
    }

    private void InformDeath()
    {
        _animation.EstablishDead();
    }
}