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
        manager.dead = true;
        manager.gameOver.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!manager.dead)
        {
            manager.score++;
            manager.txtScore.text = "Score: " + manager.score;
        }
    }


}
