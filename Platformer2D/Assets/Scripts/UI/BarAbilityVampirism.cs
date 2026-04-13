using UnityEngine;

public class BarAbilityVampirism : MonoBehaviour
{
    [SerializeField] private Vampirism _vampirism;
    [SerializeField] private SliderSmoothAnimator _smoothAnimator;

    private float _maxValue = 1;

    private void Awake()
    {
        _smoothAnimator.SetInstentValue(_maxValue);
    }

    private void OnEnable()
    {
        _vampirism.ApplyChanged += UpdateValue;
    }

    private void OnDisable()
    {
        _vampirism.ApplyChanged -= UpdateValue;
    }

    private void UpdateValue(float amount)
    {
        _smoothAnimator.SetSmoothValue(amount);
    }
}