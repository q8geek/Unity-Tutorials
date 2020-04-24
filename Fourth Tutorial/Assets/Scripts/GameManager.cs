using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float gameSpeed = 4f;
    public GameObject obstaclePrefab;
    public int score = 0;
    public bool dead = false;
    public TextMeshProUGUI txtScore;
    public GameObject gameOver;
    public bool newGame = true;
    public Jump jump;


    private void Update()
    {
        if (newGame)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOver.SetActive(false);
                score = 0;
                gameSpeed = 4f;
                jump.body.bodyType = RigidbodyType2D.Dynamic;
                jump.body.velocity = Vector3.up * jump.jumpPower;
                newGame = false;
            }
        }
        else
        {
            if (dead)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                    StartCoroutine(LoadNewGame());
                else if (Input.GetKeyDown(KeyCode.Escape))
                    Application.Quit();
            }
        }
    }

    public IEnumerator LoadNewGame()
    {
        Debug.Log("Loading a new game");
        AsyncOperation async = SceneManager.LoadSceneAsync("SampleScene");
        while (!async.isDone)
        {
            yield return null;
        }
    }

    private void Start()
    {
        txtScore.text = "Score:" + score;
        ObstacleBehavior prevObstacle = null;
        ObstacleBehavior firstObstacle = null;
        gameSpeed = 0;
        
        for (int i = 0; i < 8; i++)
        {
            Vector3 newPosition = Vector3.zero;
            newPosition.x += (i * 4) + Random.Range(-1f, 1f); ;
            newPosition.y = Random.Range(-2f, 2f);

            GameObject newObstalce = Instantiate(obstaclePrefab, newPosition, Quaternion.identity);
            ObstacleBehavior ob = newObstalce.GetComponent<ObstacleBehavior>();//.manager = this;
            
            ob.manager = this;
            
            if (prevObstacle == null)
            {
                firstObstacle = ob;
            }
            else
            {
                ob.nextObstacle = prevObstacle.gameObject;
            }
            prevObstacle = ob;
        }
        firstObstacle.nextObstacle = prevObstacle.gameObject;
    }
}
