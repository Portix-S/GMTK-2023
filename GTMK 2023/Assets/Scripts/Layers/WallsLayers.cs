using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WallsLayers : MonoBehaviour
{
    // This script handles layers so that player doesn't get infront of objects 
    //when it isn't supposed to
    [SerializeField] TilemapRenderer tilemap;
    int aux = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(aux == 0)
        {
            aux = 1;
            tilemap.sortingOrder = 20;
        }
        else
        {
            aux = 0;
            tilemap.sortingOrder = 1;
        }
    }

}
