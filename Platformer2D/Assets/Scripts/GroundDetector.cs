using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GroundDetector : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _groundTolerance = 0.005f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public bool IsGrounded()
    {
        return Mathf.Abs(_rigidbody.velocity.y) < _groundTolerance;
    }
}