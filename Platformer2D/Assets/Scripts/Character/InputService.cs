using UnityEngine;

public class InputService : MonoBehaviour
{
    public float Horizontal {  get; private set; }
    public bool JumpPressed { get; private set; }
    public bool BostPressed { get; private set; }

    private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        JumpPressed = Input.GetKeyDown(KeyCode.W);
        BostPressed = Input.GetKey(KeyCode.LeftShift);
    }
}