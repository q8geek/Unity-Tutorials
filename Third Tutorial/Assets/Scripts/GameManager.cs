using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float gameSpeed = 4f;
    public GameObject obstaclePrefab;

    private void Start()
    {
        ObstacleBehavior prevObstacle = null;
        ObstacleBehavior firstObstacle = null;

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
