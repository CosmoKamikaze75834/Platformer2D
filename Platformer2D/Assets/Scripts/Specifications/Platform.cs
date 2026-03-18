using UnityEngine;

public abstract class Platform : MonoBehaviour
{
    [SerializeField] private float _minBorder = -2f;
    [SerializeField] private float _maxBorder = 2f;
    [SerializeField] private float _speed = 3f;

    private bool _isMovingToMax = true;

    private void Update()
    {
        float currentValue = GetAxisValue();

        if (currentValue > _maxBorder)
        {
            _isMovingToMax = false;
        }

        if (currentValue < _minBorder)
        {
            _isMovingToMax = true;
        }

        if (_isMovingToMax)
        {
            currentValue += _speed * Time.deltaTime;
        }
        else
        {
            currentValue -= _speed * Time.deltaTime;
        }

        SetAxisValue(currentValue);
    }

    public abstract float GetAxisValue();

    public abstract void SetAxisValue(float value);
}