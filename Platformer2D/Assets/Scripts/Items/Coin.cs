using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action<Coin> ItemSelected;

    public void CallAction()
    {
        ItemSelected?.Invoke(this);
    }
}