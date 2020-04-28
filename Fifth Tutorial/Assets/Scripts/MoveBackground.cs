using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    public GameObject nextBackground;
    public GameObject prevBackground;
    public GameManager manager;
    public Vector3 startPosition;
    // Start is called before the first frame update
    private void Start()
    {
        //manager = GameObject.FindObjectOfType<GameManager>();
        transform.position = startPosition;
    }


    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -20f)
        {
            transform.position = nextBackground.transform.position + (Vector3.right * 20f);
        }
        transform.Translate(Vector3.left * manager.gameSpeed * Time.deltaTime);
    }
}
