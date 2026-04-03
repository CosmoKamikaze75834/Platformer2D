using UnityEngine;

public class StatesEnemy : MonoBehaviour
{
    [SerializeField] private EnemyVision _enemyVision;
    [SerializeField] private Attacker _attacker;
    [SerializeField] private Stalker _stalker;
    [SerializeField] private Patrolling _patrol;
    [SerializeField] private PatrolReturner _patrolReturner;
    [SerializeField] private Transform _player;

    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private int _pointReturn = 0;

    private bool _isChill = false;
    private bool _isAngry = false;
    private bool _isGoBack = false;

    private float _attackDelay = 2f;
    private float _nextAttackTime;

    private void Start()
    {
        _isChill = true;
    }

    private void Update()
    {
        if (_enemyVision.IsPlayerDetected(_player))
        {
            _isAngry = true;
            _isChill = false;  
            _isGoBack = false;

            if (_enemyVision.IsPlayerAttackRange(_player))
            {
                if (Time.time >= _nextAttackTime)
                {
                    _attacker.AttackHero();
                    _attacker.AttackHero();
                    _nextAttackTime = _attackDelay + Time.time;
                }
            }
        }
        else
        {
            _isGoBack = true;
            _isAngry = false;
            _isChill = true;
        }

        if (_isChill == true)
            _patrol.FollowToPoint(_waypoints, _speed);
        else if (_isAngry == true)
            _stalker.MoveToPlayer(_player, _speed);
        else if (_isGoBack == true)
            GoBack();
    }

    private void GoBack()
    {
        if (_patrolReturner.IsReturnPatrol(_waypoints[_pointReturn], _speed))
        {
            _isGoBack = false;
            _isChill = true;
        }
    }
}