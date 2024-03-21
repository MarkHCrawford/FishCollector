using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    // fishes collected
    private int fishesCaptured = 0;
    
    // current fish target
    GameObject targetFish;

    // reference to fish collector class
    private FishCollector fishcollector;

    // movement direction
    private Vector2 Direction;

    // rb2d
    private Rigidbody2D rd;

    // speed
    private float speed = 2.0f;


    // start
    private bool StartMove = false;

    // Start is called before the first frame update
    void Start()
    {
        // get the fish collector component
        fishcollector = Camera.main.GetComponent<FishCollector>();
        rd = GetComponent<Rigidbody2D>();


    }


    // Update is called once per frame
    void Update()
    {
        if (StartMove)
        {
            targetFish = fishcollector.CopyFish();
            MoveTowardFish();
        }
    }



    // click on ship and begin moving
    private void OnMouseDown()
    {
        // startmoving
        StartMove = true;
    }

    
    // remove if on top of fish
    private void OnTriggerStay2D(Collider2D collision)
    {
       if (collision.gameObject == targetFish)
        {
            fishcollector.RemoveFish();
            fishesCaptured++;
        }
    }


    // movement towards fish
    private void MoveTowardFish()
    {
        if (targetFish != null && fishesCaptured < fishcollector.GetFishCount())
        { 
            Direction = (targetFish.transform.position - transform.position).normalized;
            rd.velocity = new Vector2(Direction.x * speed, Direction.y * speed);
        }
        else
        {
            rd.velocity = Vector2.zero;
            StartMove = false;
            if (fishesCaptured < fishcollector.GetFishCount())
            {
              fishcollector.GetNextFish();
              StartMove = true;
            }
        }
        
    }


}
