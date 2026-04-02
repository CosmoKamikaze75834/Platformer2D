using System.Collections;
using UnityEngine;

public class SmoothHealthBar : BaseBar
{
    [SerializeField] private float _animationTime = 0.3f;

    private Coroutine _coroutine;
    private float _targetValue;
    private float _startValue;

    public void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
    }

    protected override void UpdateValue(float current, float max)
    {
        _targetValue = current / max;
        _startValue = Slider.value;

        Stop();
        _coroutine = StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _animationTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / _animationTime;
            progress = Mathf.Clamp01(progress);

            Slider.value = Mathf.Lerp(_startValue, _targetValue, progress);

            yield return null;
        }

        Slider.value = _targetValue;
        _coroutine = null;
    }
}