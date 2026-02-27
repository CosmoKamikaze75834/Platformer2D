using UnityEngine;

public class SpriteReversal : MonoBehaviour
{
    private float _rightRotation = 0f;
    private float _leftRotation = 180f;
    private float _neutralDirection = 0f;
    private float _axisX = 0f;
    private float _axisZ = 0f;

    public void ReflectSprite(float direction)
    {
        float yRotation = direction < _neutralDirection ? _leftRotation : _rightRotation;
        transform.rotation = Quaternion.Euler(_axisX, yRotation, _axisZ);
    }
}