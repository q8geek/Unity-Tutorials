using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI txtScore;
    public int iScore = 0;

    // Update is called once per frame
    void Update()
    {
        txtScore.text = "Score: " + iScore;
    }
}
