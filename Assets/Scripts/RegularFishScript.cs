using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*************************/
/* Mark Crawford         */
/* CSC350H               */
/* Professor Tang        */
/* 03/28/2024            */
/* Fish.cs               */
/*************************/


public class RegularFish : Fish
{

    private int pointValue = 1;
    [SerializeField] private GameObject RegFish;

    public override int PointValue
    {
        get { return pointValue; }
    }

    // Start is called before the first frame update
    void Start()
    {  
    }


    // Destroying fish
    public override int DestroyFish(GameObject fishtodestroy)
    {
        Destroy(fishtodestroy);
        return pointValue;
    }

}
