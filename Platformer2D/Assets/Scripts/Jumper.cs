using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5f;
    [SerializeField] private GroundDetector _ground;
    [SerializeField] private AnimationActions _anim;

    private Rigidbody2D _rigidbody;
    private float _horizontalForce = 0f;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && _ground.IsGrounded())
        {
            _rigidbody.AddForce(new Vector2(_horizontalForce, _jumpForce), ForceMode2D.Impulse);
            _anim.EstablishJump(true);
        }

        if (_ground.IsGrounded() && _anim.GetJumpState())
        {
            _anim.EstablishJump(false);
        }
    }
}