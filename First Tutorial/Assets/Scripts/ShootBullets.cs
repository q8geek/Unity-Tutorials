using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject shootFrom;
    public float nextBullet = 0f;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.timeSinceLevelLoad > nextBullet)
            {
                Instantiate(bulletPrefab, shootFrom.transform.position, shootFrom.transform.rotation);
                nextBullet = Time.timeSinceLevelLoad + 1f;
            }
        }
    }


}
