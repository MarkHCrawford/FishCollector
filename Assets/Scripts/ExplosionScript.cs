using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;




/*************************/
/* Mark Crawford         */
/* CSC350H               */
/* Professor Tang        */
/* 03/28/2024            */
/* ExplosionFish.cs       */
/*************************/



public class ExplosionScript : Fish
{

    [SerializeField] private GameObject ExplodeFish;
    [SerializeField] private GameObject ExplosionObj;

    GameObject newExplosion;

    private int pointValue = 3;
     
    public override int PointValue
    {
        get { return pointValue; }
    }


    private void Start()
    {

    }



    public override int DestroyFish(GameObject fishtodestroy)
    {
        newExplosion = Instantiate(ExplosionObj);
        newExplosion.transform.position = fishtodestroy.transform.position;
        Destroy(fishtodestroy);
        return pointValue;
    }


}
