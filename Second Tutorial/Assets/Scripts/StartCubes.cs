using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCubes : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 newPosition = new Vector3();
            newPosition.x = Random.Range(-50f, 50f);
            newPosition.y = Random.Range(-50f, 50f);
            newPosition.z = Random.Range(-50f, 50f);

            Instantiate(enemyPrefab, newPosition, enemyPrefab.transform.rotation);
        }
    }

}
