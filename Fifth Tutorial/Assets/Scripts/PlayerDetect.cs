using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    public GameManager manager;
    public Collider2D col;
    public AudioSource sfxCoin;
    public AudioSource sfxHit;
    public TextMeshProUGUI txtHighScore;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        manager.gameSpeed = 0f;
        col.enabled = false;
        manager.dead = true;
        manager.gameOver.SetActive(true);
        sfxHit.Play();
        int oldScore = PlayerPrefs.GetInt("high_score",0);
        txtHighScore.gameObject.SetActive(true);
        if (oldScore < manager.score)
        {
            PlayerPrefs.SetInt("high_score", manager.score);
            txtHighScore.text = "High Score: " + manager.score;
        }
        else
            txtHighScore.text = "High Score: " + oldScore;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!manager.dead)
        {
            manager.score++;
            manager.txtScore.text = "Score: " + manager.score;
            sfxCoin.Play();
        }
    }


}
