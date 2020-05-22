using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Vector3 offset;
    public Transform playerTransform;
    public float cameraSpeed = 0.025f;


    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, playerTransform.position + offset, cameraSpeed);
    }
}
