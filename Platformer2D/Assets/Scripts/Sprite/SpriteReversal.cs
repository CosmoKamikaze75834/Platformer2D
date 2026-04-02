using UnityEngine;

public class SpriteReversal : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private float _neutralDirection = 0;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ReflectSprite(float direction)
    {
        if(direction < _neutralDirection)
        {
            _spriteRenderer.flipX = true;
        }
        else if(direction > _neutralDirection)
        {
            _spriteRenderer.flipX = false;
        }
    }
}