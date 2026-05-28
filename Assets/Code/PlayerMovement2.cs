using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    [Header("Movement")]
    public Vector3 moveDir;
    public float moveSpeed;
    public Rigidbody rb;

    [Header("Cam movement")]
    public Vector3 bodyRotate;
    public Vector3 camRotate;
    public float rotateSpeed;
    public Transform cam;
    public float minClamp;
    public float maxClamp;
    // internal camera pitch tracked in degrees (-180..180)
    private float cameraPitch;

    [Header("Bait Stuff")]
    public GameObject baitPrefab;
    public GameObject bait;
    public bool baitThrown;

    [Header("Inventory Stuff")]
    public GameObject inventoryPanel;
    bool isOpen = false;

    public InventoryUI inventoryUI;
    public BattleManager battleManager;



    void Start()
    {
        // Initialize cameraPitch from current local rotation and normalize to -180..180 range
        if (cam != null)
        {
            cameraPitch = cam.localEulerAngles.x;
            if (cameraPitch > 180f)
            {
                cameraPitch -= 360f;
            }
        }
        inventoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        BodyMovement();

        // gets bait object in scene, if it exists. If not, looks for it by tag. This allows the player to throw the bait, then pick it up again and throw it again.
        if (bait == null)
        {
            //baitThrown = false;
            bait = GameObject.FindWithTag("Bobber");
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (battleManager.isBattleActive)
                return;

            if (baitThrown == false)
            {
                baitPrefab.transform.forward = transform.forward; // align bait's forward with player's forward
                Instantiate(baitPrefab, cam.position + cam.forward, cam.rotation); // spawn bait slightly in front of player
                baitThrown = true;
            }
            else
            {
                Destroy(bait);
                baitThrown = false;
                bait = null;
            }
        }
       
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            isOpen = !isOpen;

            inventoryPanel.SetActive(isOpen);

            if (isOpen)
            {
                inventoryUI.UpdateUI();
            }
        }
    }
    private void BodyMovement()
    {
        // body movement
        moveDir.x = Input.GetAxis("Horizontal");
        moveDir.z = Input.GetAxis("Vertical");
        //moveDir.y = gravity; // ensure no vertical movement from input
        rb.AddRelativeForce(moveSpeed * Time.deltaTime * moveDir, ForceMode.Impulse);

        // mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // rotate body (yaw)
        if (Mathf.Abs(mouseX) > 0f)
        {
            // use rotateSpeed as sensitivity; multiply by Time.deltaTime for frame-rate independence
            transform.Rotate(Vector3.up * (mouseX * rotateSpeed * Time.deltaTime));
        }

        // rotate camera (pitch) with clamping
        if (cam != null)
        {
            // invert mouseY to match original intent (moving mouse up looks up)
            cameraPitch -= mouseY * rotateSpeed * Time.deltaTime;
            cameraPitch = Mathf.Clamp(cameraPitch, minClamp, maxClamp);

            // apply only pitch locally to avoid messing with player's yaw
            cam.localEulerAngles = new Vector3(cameraPitch, 0f, 0f);
        }
    }
}

