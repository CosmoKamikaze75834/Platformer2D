using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jump : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;
    private float _horizontalForce = 0f;
    private float _groundTolerance = 0.005f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            _rigidbody.AddForce(new Vector2(_horizontalForce, _jumpForce), ForceMode2D.Impulse);
            _animator.SetBool("IsJump", true);
        }

        if (IsGrounded() && _animator.GetBool("IsJump"))
        {
            _animator.SetBool("IsJump", false);
        }
    }

    private bool IsGrounded()
    {
        return Mathf.Abs(_rigidbody.velocity.y) < _groundTolerance;
    }
}