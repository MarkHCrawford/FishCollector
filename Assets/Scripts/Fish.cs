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



public abstract class Fish : MonoBehaviour
{

    public abstract int PointValue { get; }


    public abstract void DestroyFish();


}
