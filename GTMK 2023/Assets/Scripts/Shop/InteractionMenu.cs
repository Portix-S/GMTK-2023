using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractionMenu : MonoBehaviour
{
    [Header("Menus")]
    [SerializeField] GameObject faceMenu;
    [SerializeField] GameObject hoodMenu;
    [SerializeField] GameObject torsoMenu;
    [SerializeField] GameObject pelveMenu;
    [SerializeField] GameObject weaponMenu;

    [Header("Renderers")]
    [SerializeField] SpriteRenderer faceRenderer;
    [SerializeField] SpriteRenderer hoodRenderer;
    [SerializeField] SpriteRenderer torsoRenderer;
    [SerializeField] SpriteRenderer pelveRenderer;
    [SerializeField] SpriteRenderer weaponRenderer;
    [SerializeField] SpriteRenderer weaponRenderer2;

    [Header("Texts")]
    [SerializeField] TextMeshProUGUI priceText;
    
    private GameObject currentMenu;
    private Sprite enterFace;
    private Sprite enterHood;
    private Sprite enterTorso;
    private Sprite enterPelve;
    private Sprite enterWeapon;
    private bool isBuyingFace;
    private bool isBuyingHood;
    private bool isBuyingTorso;
    private bool isBuyingPelve;
    private bool isBuyingWeapon;
    private bool payed;
    private int totalPrice;

    [Header("Publics")]
    public bool isBuyingSomething;
    public Sprite currentSprite;


    private void Start()
    {
        currentMenu = faceMenu;
    }

    private void Update()
    {
        // Changes price
        priceText.text = "Buy   " + totalPrice;

        // Checks if is buying some item 
        if (isBuyingFace || isBuyingHood || isBuyingTorso || isBuyingPelve || isBuyingWeapon)
            isBuyingSomething = true;
        else if ((!isBuyingFace && !isBuyingHood && !isBuyingTorso && !isBuyingPelve && !isBuyingWeapon) || payed) // Can I remove the first part?
            isBuyingSomething = false;
        
    }

    // -------------- This section Handle Shop Menus, Items and Customization -----------
    public void OpenFaceMenu()
    {
        if(currentMenu != faceMenu)
            ChangeMenu(faceMenu);
    }

    public void ChangeFace()
    {
        HandleSelectedItem(ref faceRenderer, ref isBuyingFace, enterFace);
    }

    public void OpenHoodMenu()
    {
        if(currentMenu != hoodMenu)
            ChangeMenu(hoodMenu);
    }

    public void ChangeHood()
    {
        HandleSelectedItem(ref hoodRenderer, ref isBuyingHood, enterHood);
    }

    public void OpenTorsoMenu()
    {
        if (currentMenu != torsoMenu)
            ChangeMenu(torsoMenu);
    }

    public void ChangeTorso()
    {
        HandleSelectedItem(ref torsoRenderer, ref isBuyingTorso, enterTorso);
    }

    public void OpenPelveMenu()
    {
        if (currentMenu != pelveMenu)
            ChangeMenu(pelveMenu);
    }

    public void ChangePelve()
    {
        HandleSelectedItem(ref pelveRenderer, ref isBuyingPelve, enterPelve);
    }
    public void OpenWeaponMenu()
    {
        if (currentMenu != weaponMenu)
            ChangeMenu(weaponMenu);
    }

    public void ChangeWeapon()
    {
        HandleSelectedItem(ref weaponRenderer, ref isBuyingWeapon, enterWeapon);
        HandleSelectedItem(ref weaponRenderer2, ref isBuyingWeapon, enterWeapon);
    }


    private void HandleSelectedItem(ref SpriteRenderer renderer, ref bool isBuyingItem, Sprite enterSprite)
    {
        if(renderer.sprite != currentSprite)
        {
            renderer.sprite = currentSprite;
            if(!isBuyingItem)
            {
                isBuyingItem = true;
                totalPrice += 10;
            }
        }
        if(renderer.sprite == enterSprite && isBuyingItem)
        {
            isBuyingItem = false;
            totalPrice -= 10;
        }
    }


    private void ChangeMenu(GameObject newMenu)
    {
        currentMenu.SetActive(false);
        currentMenu = newMenu;
        currentMenu.SetActive(true);
    }

    // ----- End of the section that Handles Shop Menus, Items and Customization -----


    public void BuyClothes()
    {
        // Change
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        PlayerStats playerScript = player.GetComponent<PlayerStats>();
        if (playerScript.Pay(totalPrice))
        {
            SaveClothes();
            payed = true;
            ResetShop();
            priceText.text = "Buy   " + totalPrice;
        }
    }

    private void ResetShop()
    {
        totalPrice = 0;
        isBuyingFace = false;
        isBuyingHood = false;
        isBuyingTorso = false;
        isBuyingPelve = false;
        isBuyingWeapon = false;
    }

    public void SaveClothes()
    {
        payed = false;
        enterFace = faceRenderer.sprite;
        enterHood = hoodRenderer.sprite;
        enterTorso = torsoRenderer.sprite;
        enterPelve = pelveRenderer.sprite;
        enterWeapon = weaponRenderer.sprite;
    }

    public void RestoreClothes()
    {
        faceRenderer.sprite = enterFace;
        hoodRenderer.sprite = enterHood;
        torsoRenderer.sprite = enterTorso;
        pelveRenderer.sprite = enterPelve;
        weaponRenderer.sprite = enterWeapon;
        ResetShop();
    }
}
