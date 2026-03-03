using UnityEngine;

public class PathMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private SpriteReversal _sprite;

    private int _currentPoint = 0;

    private void Update()
    {
        if (transform.position == _waypoints[_currentPoint].position)
        {
            _currentPoint = ++_currentPoint % _waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentPoint].position, _speed * Time.deltaTime);

        float direction = _waypoints[_currentPoint].position.x - transform.position.x;

        _sprite.ReflectSprite(direction);
    }
}