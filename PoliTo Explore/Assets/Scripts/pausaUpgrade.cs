using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausaUpgrade : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenuUI, canvas; //player;
   
    [SerializeField] private bool isPaused;
    private GameObject game = null;
    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("Player");
    }
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
        //        GameObject.FindGameObjectWithTag("Player").SetActive(false);
        game.SetActive(false);
        canvas.SetActive(false);
//        player.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        AudioListener.pause = true;

    }

    public void DeactivateMenu()
    {

        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
        isPaused = false;
        canvas.SetActive(true);
        game.SetActive(true);
        //  GameObject.FindGameObjectWithTag("Player").SetActive(true);
        //player.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
