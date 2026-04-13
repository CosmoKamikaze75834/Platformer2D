using UnityEngine;

public class PlayerVision : MonoBehaviour
{
    [SerializeField] private float _rangeAction;
    [SerializeField] private LayerMask _enemyLayerMask;

    public Enemy LocateEnemy()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _rangeAction, _enemyLayerMask);

        Enemy _nearestEnemy = null;
        float _minDistance = float.MaxValue;

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent(out Enemy enemy) == false)
                continue;

            Vector2 direction = enemy.transform.position - transform.position;
            float distance = direction.sqrMagnitude;

            if (distance < _minDistance)
            {
                _minDistance = distance;
                _nearestEnemy = enemy;
            }
        }

        return _nearestEnemy;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, _rangeAction);
    }
}