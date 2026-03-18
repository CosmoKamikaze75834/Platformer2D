using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Follow : MonoBehaviour
{
    [SerializeField] private SpriteReversal _sprite;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Transform _ground;

    private float _lengthRay = 1f;

    public void MoveToPlayer(Transform player, float speed)
    {
        if (IsGround() == true)
        {
            float direction = player.position.x - transform.position.x;
            _sprite.ReflectSprite(direction);

            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

        return;
    }

    private bool IsGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(_ground.position, Vector2.down, _lengthRay, _layerMask);

        return hit.collider != null;
    }
}