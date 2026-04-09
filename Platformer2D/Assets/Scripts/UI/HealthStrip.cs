using UnityEngine;
using UnityEngine.Animations;

public class HealthStrip : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 _rotationOffset;

    private void LateUpdate()
    {
        transform.rotation = _camera.transform.rotation * Quaternion.Euler(_rotationOffset);
    }
}