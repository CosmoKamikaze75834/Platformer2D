using UnityEngine;

public class PatrolReturner : MonoBehaviour
{
    private float _distance = 0.1f;

    public bool IsReturnPatrol(Transform targetPoint, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        Vector2 direction = transform.position - targetPoint.position;

        return direction.sqrMagnitude < _distance;
    }
}