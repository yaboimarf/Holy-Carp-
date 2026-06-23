using UnityEngine;

public class Casting : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject bait;
    public float throwForce;
    public Vector3 up;
    public float turnUp;
    public float turnSpeed;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        rb.AddRelativeForce(Vector3.forward * throwForce, ForceMode.Impulse);
    }
    public void Update()
    {
        if (up.x > -90)
        {
            up.x -= turnSpeed;
        }
        else
        {
            up.x += turnSpeed;
        }
        transform.localRotation = Quaternion.Euler(up * Time.deltaTime);
    }
}
