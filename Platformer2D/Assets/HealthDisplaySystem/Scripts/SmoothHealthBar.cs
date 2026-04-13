using System.Collections;
using UnityEngine;

public class SmoothHealthBar : BaseBar
{
    [SerializeField] private SliderSmoothAnimator _smoothAnimator;

    private float _targetValue;

    protected override void UpdateValue(float current, float max)
    {
         _targetValue = current / max;
        _smoothAnimator.SetSmoothValue(_targetValue);
    }
}