using UnityEngine;

public class PlatformHorizontal : Platform
{
    public override float GetAxisValue()
    {
        return transform.position.x;
    }

    public override void SetAxisValue(float value)
    {
        transform.position = new Vector2(value, transform.position.y);
    }
}