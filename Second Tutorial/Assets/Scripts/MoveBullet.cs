using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rigidBody;
    public float bulletSpeed = 50;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.AddRelativeForce(Vector3.forward * bulletSpeed,ForceMode.VelocityChange);
        Destroy(gameObject, 2f);
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
    }
}
