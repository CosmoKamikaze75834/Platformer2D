using UnityEngine;

public abstract class BaseIndicator : MonoBehaviour
{
    [SerializeField] protected Health Health;

    private void OnEnable()
    {
        Health.HealthChanged += UpdateValue;
    }

    private void OnDisable()
    {
        Health.HealthChanged -= UpdateValue;
    }

    private void UpdateValue() =>
        UpdateValue(Health.Current, Health.Max);

    protected abstract void UpdateValue(float current, float max);
}