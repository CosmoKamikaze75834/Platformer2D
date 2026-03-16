using System;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public event Action<int> ItemSelected;

    private int _reserve = 25;

    public void CallEvent()
    {
        ItemSelected?.Invoke(_reserve);
    }
}