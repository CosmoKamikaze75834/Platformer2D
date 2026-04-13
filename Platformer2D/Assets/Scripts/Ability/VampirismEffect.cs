using UnityEngine;

public class VampirismEffect : MonoBehaviour
{
    [SerializeField] private Health _healthPlayer;
    [SerializeField] private float _stolenLivesPerSecond = 3f;

    public void Apply(Enemy enemyTarget, float deltaTime)
    {
        if (enemyTarget == null)
            return;

        if (enemyTarget.TryGetComponent(out Health enemyHealth) == false)
        {
            return;
        }

        float transferHealth = _stolenLivesPerSecond * deltaTime;

        enemyHealth.Reduce(transferHealth);
        RecoverHealth(transferHealth);
    }

    private void RecoverHealth(float amount)
    {
        _healthPlayer.Increase(amount);
    }
}