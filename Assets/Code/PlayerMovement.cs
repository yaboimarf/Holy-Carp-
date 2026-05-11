using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 6f;

    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference jumpAction;
    public InputActionReference lookAction;

    [Header("Camera")]
    public Transform cam;
    public float rotateSpeed;
    public float minClamp;
    public float maxClamp;
    private float cameraPitch;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * speed);

        // mouse input
        float lookX = lookAction.action.ReadValue<Vector2>().x;
        float lookY = lookAction.action.ReadValue<Vector2>().y;

        // rotate body (yaw)
        if (Mathf.Abs(lookX) > 0f)
        {
            // use rotateSpeed as sensitivity; multiply by Time.deltaTime for frame-rate independence
            transform.Rotate(Vector3.up * (lookX * rotateSpeed * Time.deltaTime));
        }

        // rotate camera (pitch) with clamping
        if (cam != null)
        {
            // invert mouseY to match original intent (moving mouse up looks up)
            cameraPitch -= lookY * rotateSpeed * Time.deltaTime;
            cameraPitch = Mathf.Clamp(cameraPitch, minClamp, maxClamp);

            // apply only pitch locally to avoid messing with player's yaw
            cam.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);
        }
    }
}
