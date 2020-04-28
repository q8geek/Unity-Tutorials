using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public Rigidbody2D body;
    public GameManager manager;
    public float jumpPower = 12f;
    public AudioSource sfxJump;


    // Start is called before the first frame update
    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.dead)
        {
            if (!manager.newGame)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    body.velocity = Vector3.up * jumpPower;
                    sfxJump.Play();
                }
            }
        }
    }

}
