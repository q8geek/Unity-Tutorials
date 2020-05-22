using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D rBody;
    public float moveSpeed = 4f;
    public float jumpPower = 10;
    public bool jumping = false;
    public bool canJump = false;
    public GameManager manager;
    public int health = 4;

    private void Awake()
    {
        manager = FindObjectOfType<GameManager>();
        manager.mp = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //second
        rBody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime);
        //float fY = rBody.velocity.y;
        //rBody.velocity = Vector3.up * fY + Vector3.right * Input.GetAxis("Horizontal") * moveSpeed;
        //if (Input.GetAxisRaw("Vertical") > 0f && canJump)
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && canJump)
        {
            rBody.velocity += Vector2.up * jumpPower;
            canJump = false;
            manager.jumpPosition = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "CanJump")
            canJump = true;
        if (collision.gameObject.tag == "Bot")
        {
            health -= 1;
            if (health <= 0)
                ResetPlayer();
        }
    }

    void ResetPlayer()
    {
        gameObject.transform.position = manager.jumpPosition;
        rBody.velocity = Vector3.zero;
        health = 4;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.tag == "DeathTrap")
        {
            ResetPlayer();
        }
        if (collision.tag == "BotHitbox")
        {
            BotBehavior bot = collision.GetComponentInParent<BotBehavior>();
            if (bot != null)
            {
                bot.health -= 1;
                if (bot.health <= 0)
                    Destroy(bot.gameObject);
            }
        }
    }

}
