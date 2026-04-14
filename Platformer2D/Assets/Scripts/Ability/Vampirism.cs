using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private ColorChanger _colorChange;
    [SerializeField] private PlayerVision  _playerVision;
    [SerializeField] private VampirismEffect _effect;

    private bool _isReady = true;

    private float _timeRecharge = 4;
    private float _timeAbility = 6;

    private float _timeRemaining;
    private float _minValue = 0f;
    private float _maxValue = 1f;

    private Coroutine _coroutine;

    public event Action<float> ApplyChanged;

    private void Update()
    {
        if (_inputService.VampirismPressed)
        {
            if (_isReady)
            {
                _isReady = false;
                _coroutine = StartCoroutine(LaunchingAbility());
            }
        }
    }

    private IEnumerator LaunchingAbility()
    {
        _colorChange.Apply();

        _timeRemaining = _timeAbility;

        while (_timeRemaining > _minValue)
        {
            StartAbility();
            yield return null;
        }

        ApplyChanged?.Invoke(_minValue);
        _colorChange.Return();


        _timeRemaining = _minValue;

        while (_timeRemaining < _timeRecharge)
        {
            Recharge();
            yield return null;
        }

        ApplyChanged?.Invoke(_maxValue);

        _isReady = true;
    }

    private void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private void StartAbility()
    {
        Enemy _findEnemy = _playerVision.LocateEnemy();
        _effect.Apply(_findEnemy, Time.deltaTime);

        _timeRemaining -= Time.deltaTime;

        float progress = _timeRemaining / _timeAbility;
        ApplyChanged?.Invoke(progress);
    }

    private void Recharge()
    {
        _timeRemaining += Time.deltaTime;

        float progress = _timeRemaining / _timeRecharge;
        ApplyChanged?.Invoke(progress);
    }
}