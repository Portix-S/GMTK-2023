using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] GameObject hintText;
    [SerializeField] GameObject interactionMenu;
    [SerializeField] GameObject canvasCamera;
    private bool onTrigger;
    private PlayerMovement playerScript;
    private InteractionMenu interactionMenuScript;


    private void Start()
    {
        interactionMenuScript = interactionMenu.GetComponent<InteractionMenu>();
    }

    private void Update()
    {
        // Open Interaction Menu
        if(onTrigger)
        {
            if (Input.GetKeyDown(KeyCode.E))
                SetMenuActive(!playerScript.isOnMenu);
            if (playerScript.isOnMenu && Input.GetKeyDown(KeyCode.Escape))
                SetMenuActive(false);
        }
    }

    private void SetMenuActive(bool onMenu)
    {
        // Checks if player entered the shop, so it saves current clothes
        //or if player tries to leave while buying something, so it restores
        //to initial clothes
        if (onMenu)
            interactionMenuScript.SaveClothes();
        else if(interactionMenuScript.isBuyingSomething)
            interactionMenuScript.RestoreClothes();

        // Make menu active/deactive
        playerScript.isOnMenu = !playerScript.isOnMenu;
        interactionMenu.SetActive(onMenu);
        canvasCamera.SetActive(onMenu);
    }

    private void OnTriggerEnter2D(Collider2D collision) // Trigger to Open Shop
    {
        if (collision.tag == "Player")
        {
            playerScript = collision.GetComponent<PlayerMovement>();
            onTrigger = true;
            hintText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // Trigger to Exit Shop
    {
        if (collision.tag == "Player")
        {
            onTrigger = false;
            hintText.SetActive(false);
        }
    }

}
