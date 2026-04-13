using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderSmoothAnimator : MonoBehaviour
{
    [SerializeField] private float _animationTime = 0.3f;
    [SerializeField] private Slider _slider;

    private Coroutine _coroutine;
    private float _targetValue;
    private float _startValue;

    public void SetInstentValue(float value)
    {
        _slider.interactable = false;
        _slider.value = value;
    }

    public void SetSmoothValue(float amount)
    {
        _targetValue = amount;
        _startValue = _slider.value;

        Stop();
        _coroutine = StartCoroutine(ChangeValue());
    }

    private void Stop()
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);
        _coroutine = null;
    }

    private IEnumerator ChangeValue()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _animationTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / _animationTime;
            progress = Mathf.Clamp01(progress);

            _slider.value = Mathf.Lerp(_startValue, _targetValue, progress);

            yield return null;
        }

        _slider.value = _targetValue;
        _coroutine = null;
    }
}