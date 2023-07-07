using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    public bool isPaused;

    [SerializeField] private PlayerMovement playerMov;
    private GameObject player;


    private void Update()
    {
        if (!isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            playerMov.PauseMenu(true);
            pauseMenu.SetActive(true);
        }
        else if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToGame();
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReturnToGame()
    {
        isPaused = false;
        playerMov.PauseMenu(false);
        pauseMenu.SetActive(false);
    }
}
