using UnityEngine;

public class StatesEnemy : MonoBehaviour
{
    private const string NameObject = "Player";

    [SerializeField] private EnemyVision _enemyVision;
    [SerializeField] private Attack _attack;
    [SerializeField] private Follow _follow;
    [SerializeField] private Patrol _patrol;
    [SerializeField] private Comeback _comeback;

    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private int _pointReturn = 0;
    private Transform player;

    private bool chill = false;
    private bool angry = false;
    private bool goBack = false;

    private float _attackDelay = 2f;
    private float _nextAttackTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(NameObject).transform;
        chill = true;
    }

    private void Update()
    {
        if (_enemyVision.IsPlayerDetected(player))
        {
            angry = true;
            chill = false;  
            goBack = false;

            if (_enemyVision.IsPlayerAttackRange(player))
            {
                if (Time.time >= _nextAttackTime)
                {
                    _attack.AttackHero();
                    _nextAttackTime = _attackDelay + Time.time;
                }
            }
        }
        else
        {
            goBack = true;
            angry = false;
            chill = true;
        }

        if (chill == true)
            _patrol.PatrollingTerritory(_waypoints, _speed);

        else if (angry == true)
            _follow.MoveToPlayer(player, _speed);

        else if (goBack == true)
            GoBack();
    }

    private void GoBack()
    {
        if (_comeback.IsReturnPatrol(_waypoints[_pointReturn], _speed))
        {
            goBack = false;
            chill = true;
        }
    }
}