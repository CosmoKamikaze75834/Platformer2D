using UnityEngine;

public class PlayerPlatform : MonoBehaviour
{
    [SerializeField] private Platform platform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
        {
            player.transform.SetParent(platform.transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            player.transform.SetParent(null);
        }
    }
}