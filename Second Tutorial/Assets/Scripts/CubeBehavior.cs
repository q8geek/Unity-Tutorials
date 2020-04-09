using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 3;
    public ScoreManager manager;
    public Collider col;
    public Renderer ren;
    public ParticleSystem ps;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        ps.transform.position = collision.GetContact(0).point;
        ps.Play();
        health--;
        if (health > 0)
            manager.iScore++;
        else
        {
            col.enabled = false;
            ren.enabled = false;
            Destroy(gameObject,1f);
            manager.iScore += 5;
        }
    }
}
