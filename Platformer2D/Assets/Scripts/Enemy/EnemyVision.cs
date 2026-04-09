using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private float _stoppingDistance = 10;
    [SerializeField] private float _attackDistance = 2f;

    public bool IsPlayerDetected(Transform player)
    {
        Vector2 direction = transform.position - player.position;
        return direction.sqrMagnitude < (_stoppingDistance * _stoppingDistance);
    }

    public bool IsPlayerAttackRange(Transform player)
    {
        Vector2 direction = transform.position - player.position;
        return direction.sqrMagnitude < (_attackDistance * _attackDistance);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _stoppingDistance);
        Gizmos.DrawWireSphere(transform.position, _attackDistance);
    }
}