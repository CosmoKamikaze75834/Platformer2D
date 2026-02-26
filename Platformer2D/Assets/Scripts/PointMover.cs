using UnityEngine;

public class PointMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;

    private int _currentPoint = 0;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (transform.position == _waypoints[_currentPoint].position)
        {
            _currentPoint = ++_currentPoint % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentPoint].position, _speed * Time.deltaTime);

        float direction = _waypoints[_currentPoint].position.x - transform.position.x;

        ReflectSprite(direction);
    }

    private void ReflectSprite(float direction)
    {
        _renderer.flipX = direction < 0;
    }
}