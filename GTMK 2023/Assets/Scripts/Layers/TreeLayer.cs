using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLayer : MonoBehaviour
{
    // This script handles layers so that player doesn't get infront of objects 
    //when it isn't supposed to

    [SerializeField] SpriteRenderer[] sprites;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            foreach(SpriteRenderer sprite in sprites)
            {
                sprite.sortingOrder = 0;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            foreach (SpriteRenderer sprite in sprites)
            {
                sprite.sortingOrder = 20;
            }
        }
    }

}
