using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class DeathEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Health _health;

    private void OnEnable()
    {
        _health.Died += StopComponent;
    }

    private void OnDisable()
    {
        _health.Died -= StopComponent;
    }

    public void StopComponent()
    {
        _enemy.GetComponent<Collider2D> ().enabled = false;
        _enemy.GetComponent<StatesEnemy> ().enabled = false;

        var rigidbody2D = _enemy.GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = Vector2.zero;
    }
}