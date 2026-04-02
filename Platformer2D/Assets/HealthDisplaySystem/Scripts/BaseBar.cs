using UnityEngine;
using UnityEngine.UI;

public abstract class BaseBar : BaseIndicator
{
    [SerializeField] protected Slider Slider;

    private void Start()
    {
        Slider.interactable = false;
        UpdateValue(Health.Current, Health.Max);
    }
}