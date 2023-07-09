using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject tutorialMenu;
    [SerializeField] GameObject CreditsMenu;


    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenMenu()
    {
        mainMenu.SetActive(true);
        tutorialMenu.SetActive(false);
        CreditsMenu.SetActive(false);
    }

    public void OpenTutorial()
    {
        mainMenu.SetActive(false);
        tutorialMenu.SetActive(true);
        CreditsMenu.SetActive(false);
    }

    public void OpenCredits()
    {
        mainMenu.SetActive(false);
        tutorialMenu.SetActive(false);
        CreditsMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
