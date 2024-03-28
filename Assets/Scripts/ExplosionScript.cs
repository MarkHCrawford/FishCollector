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



public class ExplosionFish : Fish
{

    private GameObject ExplodeFish;
    private GameObject ExplosionObj;

    private int pointValue = 3;
     
    public override int PointValue
    {
        get { return pointValue; }
    }


    private void Start()
    {
        ExplodeFish = GameObject.Find("ExplodingFish");
        ExplosionObj = GameObject.Find("Explosion");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Player")
        {
            Instantiate(ExplosionObj);
            ExplosionObj.transform.position = ExplodeFish.transform.position;
        }
    }

    public override void DestroyFish()
    {
        Destroy(ExplodeFish);
    }


}
