using UnityEngine;

public class StatesEnemy : MonoBehaviour
{
    [SerializeField] private EnemyVision _enemyVision;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Stalker _stalker;
    [SerializeField] private Patrolling _patrol;
    [SerializeField] private Transform _player;

    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private float _attackDelay = 2f;
    private float _nextAttackTime;

    private void Update()
    {
        if (_enemyVision.IsPlayerDetected(_player))
        {
            _stalker.MoveToPlayer(_player, _speed);

            if (_enemyVision.IsPlayerAttackRange(_player))
            {
                if (Time.time >= _nextAttackTime)
                {
                    _attacker.AttackHero();
                    _nextAttackTime = _attackDelay + Time.time;
                }
            }
        }
        else
        {
            _patrol.FollowToPoint(_waypoints, _speed);
        }
    }
}