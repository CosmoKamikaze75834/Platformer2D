using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> CoinSelected;

    public void CallAction()
    {
        CoinSelected?.Invoke(this);
    }
}