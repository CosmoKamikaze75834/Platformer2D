using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> CoinSelected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out _))
        {
            CoinSelected?.Invoke(this);
        }
    }
}