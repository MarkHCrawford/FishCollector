using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    //fish count
    int currentFish = 0;

    // current fish target
    GameObject targetFish;

    // reference to fish collector class
    public FishCollector fishcollector;

    // movement direction
    public Vector2 Direction;

    // rb2d
    public Rigidbody2D rd;

    // speed
    public float speed = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        // get the fish collector component
        fishcollector = gameObject.GetComponent<FishCollector>();
        rd = GetComponent<Rigidbody2D>();

    }


    // Update is called once per frame
    void Update()
    {
        while (fishcollector.fishList.Count != 0)
        {
            // get the first fish in the list
            targetFish = fishcollector.fishList[currentFish];

            // get the direction to move
            Direction = new Vector2(targetFish.transform.position.x - transform.position.x,
                targetFish.transform.position.y - transform.position.y);

            // normalize the direction
            Direction.Normalize();

            // move the ship
            GetNextFish();
        }
    }



    private void OnMouseDown()
    {
        if(fishcollector.fishList.Count != 0)
        {
            rd.AddForce(Direction * speed, ForceMode2D.Force);  

        }

    }

    
    public void OnTriggerStay2D(Collider2D collision)
    {
       if (collision.gameObject == targetFish)
        {

            // reset ship movement
            rd.velocity = Vector2.zero;

            // destroy the fish
            Destroy(targetFish);
            fishcollector.fishList.Remove(targetFish);
            currentFish++;
        }
    }



    // get next fish
    public void GetNextFish()
    {
        rd.AddForce(Direction * speed, ForceMode2D.Impulse);
    }

}
