using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


/*************************/
/* Mark Crawford         */
/* CSC350H               */
/* Professor Tang        */
/* 03/28/2024            */
/* FishCollector.cs      */
/*************************/


public class FishCollector : MonoBehaviour
{
    // Fish types
    [SerializeField] private GameObject RegularFish;
    [SerializeField] private GameObject ExplosionFish;
    [SerializeField] private GameObject BurningFish;

    // counter for current fish
    private int currentFish = 0;
    private List<GameObject> fishList = new List<GameObject>();


    // Score Counter
    private int score = 0;


    // Score UI
    HUD playerScore;


    private void Start()
    {
        playerScore = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>(); 
    }


    // Update is called once per frame
    void Update()
    {
        PlaceFish();
    }


    // get fish count
    public int GetFishCount()
    {
        return fishList.Count;
    }


    //Destroy current fish
    public void RemoveFish()
    {
        if (currentFish < fishList.Count)
        {
            score = fishList[currentFish].GetComponent<Fish>().DestroyFish(fishList[currentFish]);
            playerScore.AddPoints(score);
            GetNextFish();
        }
    }

    // Get next fish
    public void GetNextFish()
    {
        if (currentFish < fishList.Count)
        {
            currentFish++;
        }
    }


    // Send fish to ship for location
    public GameObject CopyFish()
    {
        if (currentFish < fishList.Count)
        {
            return fishList[currentFish];
        }
        else
        {
            return null;
        }
    }



    // Place fish on right click
    private void PlaceFish()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

            //get random fish
            GameObject newfish = Instantiate(RandomFish());

            // set location
            newfish.transform.position = worldPosition;

            // add to list
            fishList.Add(newfish);
        }
    }


    // Return specific fish
    public GameObject RandomFish()
    {
        switch (Random.Range(0,3))
        {
            case 0:
                return RegularFish;
            case 1:
                return ExplosionFish;
            case 2:
                return BurningFish;
            default:
                return RegularFish;
        }

    }
}
