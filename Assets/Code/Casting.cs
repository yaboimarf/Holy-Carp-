using UnityEngine;

public class Casting : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject bait;
    public float throwForce;
    public Vector3 up;
    public Vector3 location;
    public float turnUp;
    public float turnSpeed;
    private void Start()
    {
        location = transform.position;
        up.x = -90;
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        rb.AddRelativeForce(Vector3.forward * throwForce, ForceMode.Impulse);
        transform.rotation = Quaternion.Euler(up);
    }
}
