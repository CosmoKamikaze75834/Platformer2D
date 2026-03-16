using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private SpriteReversal _sprite;

    private int _currentPoint = 0;

    public void PatrollingTerritory(Transform[] waypoints, float speed)
    {
        if (transform.position == waypoints[_currentPoint].position)
        {
            _currentPoint = ++_currentPoint % waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[_currentPoint].position, speed * Time.deltaTime);

        float direction = waypoints[_currentPoint].position.x - transform.position.x;

        _sprite.ReflectSprite(direction);
    }
}