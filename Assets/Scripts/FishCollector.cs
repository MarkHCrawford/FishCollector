using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollector : MonoBehaviour
{
    [SerializeField]
    private GameObject Fish;
    private int currentFish = 0;
    private List<GameObject> fishList = new List<GameObject>();




    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(fishList[currentFish]);
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
            GameObject newfish = Instantiate(Fish);
            newfish.transform.position = worldPosition;
            fishList.Add(newfish);
        }
    }

}
