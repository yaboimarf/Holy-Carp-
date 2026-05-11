using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementTest : MonoBehaviour
{
    public float playerSpeed;
    public float jumpHeight;
    private float gravityValue = -9.81f;

    public CharacterController controller;
    public Vector3 playerVelocity;
    public bool groundedPlayer;

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

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
        lookAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
        lookAction.action.Disable();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            // Slight downward velocity to keep grounded stable
            if (playerVelocity.y < -2f)
                playerVelocity.y = -2f;
        }

        // Read input
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        transform.Translate(move * playerSpeed* Time.deltaTime, Space.Self);
        //move = Vector3.ClampMagnitude(move, 1f);
        //move = transform.InverseTransformDirections(move); // convert from world to local space

        //if (move != Vector3.zero)
        //    transform.forward = move;

        // Jump using WasPressedThisFrame()
        if (groundedPlayer && jumpAction.action.WasPressedThisFrame())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Move
        //Vector3 finalMove = move * playerSpeed + Vector3.up * playerVelocity.y;
        //controller.Move(finalMove * Time.deltaTime);
        Vector3 finalMove = Vector3.up * playerVelocity.y;
        controller.Move(finalMove * Time.deltaTime);

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