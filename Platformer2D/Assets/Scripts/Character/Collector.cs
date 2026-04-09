using UnityEditor.MPE;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Health _health;

    private int _quantityCoins;

    public int QuantityCoins => _quantityCoins;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            _quantityCoins++;
            coin.CallAction();
        }
        else if(collision.TryGetComponent(out Apple apple))
        {
            RestoreHealth(apple.Reserve);

            Destroy(apple.gameObject);
        }
    }

    private void RestoreHealth(int amount)
    {
        _health.Increase(amount);
    }
}