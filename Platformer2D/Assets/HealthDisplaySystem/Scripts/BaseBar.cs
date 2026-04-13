using UnityEngine;
using UnityEngine.UI;

public abstract class BaseBar : BaseIndicator
{
    [SerializeField] protected Slider _slider;

    private void Start()
    {
        _slider.interactable = false;
        UpdateValue(Health.Current, Health.Max);
    }
}