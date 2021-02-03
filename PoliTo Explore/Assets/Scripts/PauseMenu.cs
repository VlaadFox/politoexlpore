using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI, miniMap, bigMap, handGrab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPaused)
            {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        miniMap.SetActive(true);
        handGrab.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause() {
        pauseMenuUI.SetActive(true);
        miniMap.SetActive(false);
        handGrab.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Commands() {
        Debug.Log("Caricamento comandi...");
    }
    public void Map()
    {
        Debug.Log("Caricamento mappa..");
    }
    public void QuitGame() {
        Debug.Log("Quitting game..");
        Application.Quit();
    }


}
