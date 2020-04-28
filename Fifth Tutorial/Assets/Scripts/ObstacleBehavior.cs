using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public GameManager manager;
    public GameObject nextObstacle;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * manager.gameSpeed * Time.deltaTime);
        if (transform.position.x < -10f)
        {
            transform.position = nextObstacle.transform.position + Vector3.right * (4 + Random.Range(-1f, 1f));
        }
    }
}
