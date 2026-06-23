using Unity.VisualScripting;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    public GameObject respawnPoint;
    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.gameObject.tag == "Player")
        {
            collisionInfo.gameObject.transform.position = respawnPoint.transform.position;
        }
    }
}
