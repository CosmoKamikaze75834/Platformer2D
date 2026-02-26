using System;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;

    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody2D;

    private float _maxSpeed = 10;
    private float _minSpeed = 5;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _maxSpeed;
        }
        else
        {
            _speed = _minSpeed;
        }

        float movement = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(movement * _speed, _rigidbody2D.velocity.y);

        ReflectSprite(movement);

        _animator.SetFloat("Speed", Mathf.Abs(movement));
    }

    private void ReflectSprite(float direction)
    {
        _renderer.flipX = direction < 0;
    }
}