using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*************************************/
/* Mark Crawford                     */
/* CSC350H                           */
/* Professor Tang                    */
/* Score UI                          */
/* 04/04/2024                        */
/*************************************/


public class HUD : MonoBehaviour
{
    // scoring variables

    //text mesh pro text
    [SerializeField]
    TMPro.TMP_Text Score;  
    int score;
    const string ScorePrefix = "Score: ";


    //Initializing hud
    void Start()
    { 
        Score.text = ScorePrefix + score.ToString();
    }


    // Adding points
    public void AddPoints(int points)
    {
        score += points;
        Score.text = ScorePrefix + score.ToString();
    }
}