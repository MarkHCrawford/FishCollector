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


public class FireScript : Fish
{
    // point value
    private int pointValue = 5;

    // prefabs to attach
    [SerializeField] private GameObject FireFish;
    [SerializeField] private GameObject Burning;

    // temp objects
    private GameObject newflame;

    // Timer for burning
    private float burnTime = 3.0f;
    private bool isBurning = false;


    // get score value
    public override int PointValue
    {
        get { return pointValue; }
    }





    // Update
    private void Update()
    {
        if (isBurning)
        {
            burnTime -= Time.deltaTime;
            if (burnTime <= 0)
            {
                Destroy(newflame);
                isBurning = false;
            }
        }
    }


    // Destroy fish
    public override int DestroyFish(GameObject fishdestroy)
    {
        newflame = Instantiate(Burning);
        newflame.transform.position = fishdestroy.transform.position;
        Destroy(fishdestroy);
        Destroy(newflame, 3.0f);
        return pointValue;
    }

}

