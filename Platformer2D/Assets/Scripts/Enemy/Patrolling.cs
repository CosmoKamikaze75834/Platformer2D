using UnityEngine;

public class Patrolling : MonoBehaviour
{
    [SerializeField] private SpriteReversal _sprite;

    private int _currentPoint = 0;

    public void FollowToPoint(Transform[] waypoints, float speed)
    {
        Vector3 position = waypoints[_currentPoint].position;

        if (transform.position == position)
        {
            _currentPoint = ++_currentPoint % waypoints.Length;
        }

        transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);

        float direction = position.x - transform.position.x;

        _sprite.ReflectSprite(direction);
    }
}