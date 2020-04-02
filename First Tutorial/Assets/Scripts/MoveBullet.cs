using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rigidbody;
    public float bulletSpeed = 50;

    private void Start()
    {
        rigidbody.AddRelativeForce(Vector3.forward * bulletSpeed,ForceMode.VelocityChange);
        Destroy(gameObject, 2f);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
