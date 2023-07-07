using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChestInteraction : MonoBehaviour
{
    // This script shows hint on chest, as well as how the interaction with
    //chests works, giving 5 money each time one is oppened


    [SerializeField] Sprite openedChest;
    [SerializeField] TextMeshProUGUI chestHint;

    SpriteRenderer spriteRenderer;
    private Sprite closedChest;

    public bool isOpen;
    

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        closedChest = spriteRenderer.sprite;
        chestHint = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void CloseChest()
    {
        Debug.Log("closing");
        isOpen = false;
        spriteRenderer.sprite = closedChest;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !isOpen)
        {
            chestHint.text = "E";
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            chestHint.text = " ";
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !isOpen)
        {
            if(Input.GetKey(KeyCode.E))
            {
                isOpen = true;
                gameObject.GetComponent<SpriteRenderer>().sprite = openedChest;
                //Change
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                PlayerStats playerScript = player.GetComponent<PlayerStats>();
                playerScript.Pay(-5);
                //GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().Pay(-5);
                chestHint.text = " ";
            }
        }
    }
}
