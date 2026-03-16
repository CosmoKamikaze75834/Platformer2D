using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private const float PauseTimeScale = 0f;

    [SerializeField] private Health _playerHealth;

    private void OnEnable()
    {
        _playerHealth.Died += StopGame;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= StopGame;
    }

    public void StopGame()
    {
        Time.timeScale = PauseTimeScale;
    }
}