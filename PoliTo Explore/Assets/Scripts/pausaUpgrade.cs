using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausaUpgrade : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI, canvas, player;
   
    [SerializeField] private bool isPaused;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            ActiveteMenu();
        }
        else
        {
            DeactivateMenu();
        }
    }

    void ActiveteMenu()
    {
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
        canvas.SetActive(false);
        player.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

    }

    public void DeactivateMenu()
    {

        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isPaused = false;
        canvas.SetActive(true);
        player.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
