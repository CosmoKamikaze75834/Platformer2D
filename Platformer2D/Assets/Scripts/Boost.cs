using UnityEngine;

public class Boost : MonoBehaviour
{
    [SerializeField] private PlayerMovement _movement;

    private float _maxSpeed = 10;
    private float _minSpeed = 5;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _movement.ChangeSpeed(_maxSpeed);
        }
        else
        {
            _movement.ChangeSpeed(_minSpeed);
        }
    }
}