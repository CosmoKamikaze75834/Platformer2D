using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.CallAction();
        }
    }
}