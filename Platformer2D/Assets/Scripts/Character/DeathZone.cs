using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private DeathPlayer _player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out _))
        {
            _player.EstablishPause();
        }
    }
}