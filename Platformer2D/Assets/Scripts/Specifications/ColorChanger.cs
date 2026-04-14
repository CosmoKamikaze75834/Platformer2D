using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private float _alpha = 0.3f;

    private Color _startColor;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _startColor = _renderer.color;
    }

    public void Apply()
    {
        Color newColor = Color.blue;
        newColor.a = _alpha;

        _renderer.color = newColor;
    }

    public void Return()
    {
        _renderer.color = _startColor;
    }
}