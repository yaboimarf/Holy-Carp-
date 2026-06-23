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
        up.x = turnUp;
        if (turnUp > -90)
        {
            turnUp -= Time.deltaTime * turnSpeed;
        }
    }
}
