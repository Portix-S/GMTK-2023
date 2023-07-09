using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] private GameObject shopUI;
    public GameManager gm;

    public enum menuType{CLOTHES, TOOLS, ARCHIVES}
    public menuType menuT;
    private SpriteRenderer zombieRenderer;
    private Sprite currentSprite;
    public Sprite selectedSprite;

    private RaiseTheDead.jobs zombieJob;
    public RaiseTheDead.jobs checkJob;
    public int pontuationValue = 10;

    private void Start() {
        shopUI.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            CloseBuyMenu();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Zombie" && !gm.isMenuOpen){
            ZombieAI zombieAi = other.gameObject.GetComponent<ZombieAI>();
            if(!zombieAi.isTakingKnockBack){
                return;
            }
            zombieJob = zombieAi.job;
            //zombieRenderer = other.gameObject.transform.GetChild((int) menuT + 1).GetComponent<SpriteRenderer>();
            //currentSprite = zombieRenderer.sprite;
            OpenBuyMenu();
        }
    }

    private void OpenBuyMenu(){
        gm.isMenuOpen = true;
        Time.timeScale = 0f;
        shopUI.SetActive(true);
    }

    private void CloseBuyMenu(){
        gm.isMenuOpen = false;
        Time.timeScale = 1f;
        shopUI.SetActive(false);
    }

    public void HandleSelected(){
        //zombieRenderer.sprite = selectedSprite;
    }

    public void ApplyChanges(){
        if(checkJob == zombieJob) gm.points += pontuationValue;
        else gm.points -= pontuationValue;

        CloseBuyMenu();
        //currentSprite = selectedSprite;
        //zombieRenderer.sprite = selectedSprite;
    }

    public void UndoChanges(){
        if(checkJob == zombieJob) gm.points -= pontuationValue;
        else gm.points += pontuationValue;

        CloseBuyMenu();
        //zombieRenderer.sprite = currentSprite;
    }
}
