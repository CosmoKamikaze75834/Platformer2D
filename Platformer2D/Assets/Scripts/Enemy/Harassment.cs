using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Harassment : MonoBehaviour
{
    [SerializeField] private SpriteReversal _sprite;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void MoveToPlayer(Transform player, float speed)
    {
        float direction = player.position.x - transform.position.x;
        _sprite.ReflectSprite(direction);

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }
}