using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject tutorialMenu;

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void OpenTutorial()
    {
        mainMenu.SetActive(false);
        tutorialMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        tutorialMenu.SetActive(false);
    }
}
