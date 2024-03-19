using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCollector : MonoBehaviour
{
    public GameObject Fish;
    private int currentFish = 0;
    private List<GameObject> fishList = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
    
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = -Camera.main.transform.position.z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            GameObject newfish = Instantiate<GameObject>(Fish);
            newfish.transform.position = worldPosition;
            fishList.Add(newfish);
        }
    }


    //Destroy current fish
    public void RemoveFish()
    {
        if (currentFish < fishList.Count - 1)
        {
            Destroy(fishList[currentFish]);
            fishList.RemoveAt(currentFish);
        }
    }

    // Get next fish
    public void GetNextFish()
    {
        if (currentFish < fishList.Count - 1)
        {
            currentFish++;
        }
    }


}
