using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputService _inputService;
    [SerializeField] private float _speed;
    [SerializeField] private AnimationActions _animation;
    [SerializeField] private SpriteReversal _sprite;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float movement = _inputService.Horizontal;
        _rigidbody2D.velocity = new Vector2(movement * _speed, _rigidbody2D.velocity.y);

        _animation.EstablishSpeed(movement);
        _sprite.ReflectSprite(movement);
    }

    public void ChangeSpeed(float speed)
    {
        _speed = speed;
    }
}