using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float moveSpeed = 0.025f;
    public float turnSpeed = 5f;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveVector = (Vector3.right * Input.GetAxis("Horizontal") + Vector3.forward * Input.GetAxis("Vertical")) * moveSpeed;
        transform.Translate(moveVector);

        Vector3 turnVector = (Vector3.up * Input.GetAxis("Mouse X") + Vector3.right * Input.GetAxis("Mouse Y")) * turnSpeed;
        transform.Rotate(turnVector);
    }
}
