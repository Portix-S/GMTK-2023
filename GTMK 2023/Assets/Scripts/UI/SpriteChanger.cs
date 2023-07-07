using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour
{
    // This Script get the sprites that will be changed on the character

    [SerializeField] Sprite sprite;
    InteractionMenu menuScript;
    private void Start()
    {
        if(gameObject.tag != "Weapon")
            sprite = ((Image)GetComponent<Button>().targetGraphic).sprite;
        menuScript = GameObject.FindGameObjectWithTag("Menu").GetComponent<InteractionMenu>();
    }

    public void ChangeSprite()
    {
        menuScript.currentSprite = sprite;
    }

}
