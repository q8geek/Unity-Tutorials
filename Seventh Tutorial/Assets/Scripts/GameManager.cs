using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Vector2 jumpPosition;
    public MovePlayer mp;
    public Image imgHealth;

    private void Update()
    {
        imgHealth.fillAmount = Mathf.Lerp(imgHealth.fillAmount, (float) mp.health/ 4f, 0.5f);
        //imgHealth.fillAmount = (float)mp.health / (float)4;
    }



}
