using UnityEngine;

public class Casting : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject bait;
    public float throwForce;

    private void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        rb.AddRelativeForce(Vector3.forward * throwForce, ForceMode.Impulse);

    }
}
