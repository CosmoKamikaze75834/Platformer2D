using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Health _health;

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
        var rigidbody2D = _player.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.zero;

        Time.timeScale = 0;
    }
}