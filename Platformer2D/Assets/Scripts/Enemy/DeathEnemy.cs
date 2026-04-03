using UnityEngine;

public class DeathEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Health _health;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = _enemy.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        _health.Died += StopComponents;
    }

    private void OnDisable()
    {
        _health.Died -= StopComponents;
    }

    public void StopComponents()
    {
        DisableComponent<Collider2D>();
        DisableComponent<StatesEnemy>();

        _rigidbody.velocity = Vector2.zero;
    }

    private void DisableComponent<T>() where T : Behaviour
    {
        if(_enemy.TryGetComponent(out T component))
        {
            component.enabled = false;
        }
    }
}