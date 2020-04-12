using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public GameManager manager;
    public Collider2D col;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.gameSpeed = 0f;
        col.enabled = false;
    }

}
