using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;


/*************************/
/* Mark Crawford         */
/* CSC350H               */
/* Professor Tang        */
/* 03/28/2024            */
/* BurningFish.cs        */
/*************************/


public class BurningFish : Fish
{
    private int pointValue = 5;
    private GameObject FireFish;
    private GameObject Burning;

    // Timer for burning
    private float burnTime = 5.0f;
    private bool isBurning = false;


    // get score value
    public override int PointValue
    {
        get { return pointValue; }
    }


    // on start
    private void Start()
    {
        FireFish = GameObject.Find("BurningFish");
        Burning = GameObject.Find("Fire");
    }
    

    // Update
    private void Update()
    {
        if (isBurning)
        {
            burnTime -= Time.deltaTime;
            if (burnTime <= 0)
            {
                Destroy(FireFish);
                Destroy(Burning);
            }
        }
    }


    // Destroy fish
    public override void DestroyFish()
    {
        Instantiate(Burning);
        Burning.transform.position = FireFish.transform.position;
        StartBurning();
    }


    // Start burning
    public void StartBurning()
    {
        isBurning = true;
    }

}
