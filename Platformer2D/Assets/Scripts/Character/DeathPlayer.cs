using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Health _health;

    private float _timePlay = 0;

    private void OnEnable()
    {
        _health.Died += StopScene;
    }

    private void OnDisable()
    {
        _health.Died -= StopScene;
    }

    public void StopScene()
    {
        _player.GetComponent<PlayerMovement>().enabled = false;

        Time.timeScale = _timePlay;
    }
}