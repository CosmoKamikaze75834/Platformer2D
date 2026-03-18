using UnityEngine;

public class PlatformVertical : Platform
{
    public override float GetAxisValue()
    {
        return transform.position.y;
    }

    public override void SetAxisValue(float value)
    {
        transform.position = new Vector2(transform.position.x, value);
    }
}