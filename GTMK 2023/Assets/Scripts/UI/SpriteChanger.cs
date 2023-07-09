using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    // This Script get the sprites that will be changed on the character

    private Sprite sprite;
    public OpenMenu shop;
    public RaiseTheDead.jobs assignedJob;
    InteractionMenu menuScript;
    private void Start(){
        sprite = GetComponentInChildren<Image>().sprite;
    }

    public void ChangeSprite(){
        shop.selectedSprite = sprite;
        shop.checkJob = assignedJob;
    }

}
