using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Health _health;

    private float _timePlay = 0;

    private void OnEnable()
    {
        _health.Died += EstablishPause;
    }

    private void OnDisable()
    {
        _health.Died -= EstablishPause;
    }

    public void EstablishPause()
    {
        TurnOffMovement();

        Time.timeScale = _timePlay;
    }

    private void TurnOffMovement()
    {
        if (_player.TryGetComponent(out PlayerMovement component))
        {
            component.enabled = false;
        }
    }
}