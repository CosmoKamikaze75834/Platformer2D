using UnityEngine;

public class PlayerAttackDetector : MonoBehaviour
{
    [SerializeField] private int _attackDamage = 10;//урон
    [SerializeField] private Transform _attackPoint;//точка откуда исходит урон
    [SerializeField] private float _attackRange = 0.5f;//радиус атаки
    [SerializeField] private LayerMask _enemyLaers;//слой врагов

    public bool Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(_attackPoint.position, _attackRange, _enemyLaers);

        bool damageApplied = false;

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.TryGetComponent(out Health health))
            {
                health.TakeDamage(_attackDamage);
                Debug.Log("Нанесли урон" + enemy.name);
                damageApplied = true;
            }
        }

        return damageApplied;
    }

    private void OnDrawGizmosSelected()
    {
        if (_attackPoint == null)
            return;

        Gizmos.DrawWireSphere(_attackPoint.position, _attackRange);
    }
}