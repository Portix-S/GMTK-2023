using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEnvironment : MonoBehaviour
{
    // This Script handles changing scenarios, from interior to exteriors

    [SerializeField] GameObject currentLocation;
    [SerializeField] GameObject newLocation;
    [SerializeField] GameObject[] chests;

    public void ChangeLocation()
    {
        currentLocation.SetActive(false);
        newLocation.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (currentLocation.name == "Exterior") // Closes all chests so player can get more money.
        {
            RestoreChests();
        }
        ChangeLocation();
    }

    private void RestoreChests()
    {
        foreach(GameObject chest in chests)
        {
            chest.GetComponent<ChestInteraction>().CloseChest();
        }
    }


}
