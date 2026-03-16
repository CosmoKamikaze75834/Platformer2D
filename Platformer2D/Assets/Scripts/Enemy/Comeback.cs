using UnityEngine;

public class Comeback : MonoBehaviour
{
    private float _distance = 0.1f;

    public bool IsReturnPatrol(Transform targetPoint, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        return Vector2.Distance(transform.position, targetPoint.position) < _distance;
    }
}