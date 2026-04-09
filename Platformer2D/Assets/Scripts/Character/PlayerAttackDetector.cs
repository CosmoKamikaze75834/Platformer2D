using UnityEngine;

public class PlayerAttackDetector : MonoBehaviour
{
    [SerializeField] private int _attackDamage = 10;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private float _attackRange = 0.5f;
    [SerializeField] private LayerMask _enemyLaers;

    public bool Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLaers);

        bool isdamageApplied = false;

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.TryGetComponent(out Health health))
            {
                health.Reduce(_attackDamage);
                isdamageApplied = true;
            }
        }

        return isdamageApplied;
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}