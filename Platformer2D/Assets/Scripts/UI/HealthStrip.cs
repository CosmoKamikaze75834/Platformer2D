using UnityEngine;
using UnityEngine.Animations;

public class HealthStrip : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 _rotationOffset;

    private void LateUpdate()
    {
        if (_camera == null) return;

        // Направление от объекта к камере
        Vector3 direction = _camera.transform.position - transform.position;

        // Поворачиваем объект лицом к камере (ось Z смотрит на камеру)
        Quaternion lookRotation = Quaternion.LookRotation(direction, _camera.transform.up);

        // Применяем дополнительное смещение, если нужно
        transform.rotation = lookRotation * Quaternion.Euler(_rotationOffset);
    }
}