using UnityEngine;

public class PlayerInput : MonoBehaviour {
    public delegate void PlayerAxisInputDelegate(Vector2 input);
    public delegate void PlayerKeyInputDelegate();

    public event PlayerAxisInputDelegate DirectionalInputEvent;
    public event PlayerKeyInputDelegate JumpPressedEvent;
    public event PlayerKeyInputDelegate DashPressedEvent;

    private void Update() {
        DirectionalInputEvent?.Invoke(new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")));

        if (Input.GetKeyDown(KeyCode.Space) && JumpPressedEvent != null) {
            JumpPressedEvent();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && DashPressedEvent != null) {
            DashPressedEvent();
        }
    }
}