using UnityEngine;

public class DownPlayer : MonoBehaviour
{
    [SerializeField] private DeathPlayer _player;
    [SerializeField] private Health _health;

    private float _border = -7f;
    private int _fallDamage = 100;

    private void Update()
    {
        if(transform.position.y < _border)
        {
            _player.StopScene();
            _health.TakeDamage(_fallDamage);
        }
    }
}