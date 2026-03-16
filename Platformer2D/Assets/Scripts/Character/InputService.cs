using UnityEngine;

public class InputService : MonoBehaviour
{
    private const string HorizontalAxis = "Horizontal";
    private const KeyCode JumpKey = KeyCode.W;
    private const KeyCode BoostKey = KeyCode.LeftShift;
    private const int MouseLeftButton = 0;

    public bool AttackPressed { get; private set; }
    public float Horizontal {  get; private set; }
    public bool JumpPressed { get; private set; }
    public bool BostPressed { get; private set; }

    private void Update()
    {
        Horizontal = Input.GetAxis(HorizontalAxis);
        JumpPressed = Input.GetKeyDown(JumpKey);
        BostPressed = Input.GetKey(BoostKey);
        AttackPressed = Input.GetMouseButtonDown(MouseLeftButton);
    }
}