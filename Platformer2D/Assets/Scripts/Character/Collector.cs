using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField] private Health _health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Coin coin))
        {
            coin.CallAction();
        }
        else if(collision.TryGetComponent(out Apple apple))
        {
            apple.ItemSelected += ProcessEvent;
            apple.CallEvent();

            Destroy(apple.gameObject);
        }
    }

    private void ProcessEvent(int amount)
    {
        _health.Heal(amount);
    }
}