using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlM : MonoBehaviour
{

    [SerializeField] private GameObject bigMap, canvas, canvas1, canvas2; // player;

    [SerializeField] private bool isPaused;
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.M))
        {
            if (bigMap.active) { downMap(); }
            else
            {
                mapOnScreen();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (bigMap.active) { downMap(); }
        }*/
        if (Input.GetKeyDown(KeyCode.M))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            mapOnScreen();
        }
        else
        {
            downMap();
        }
    }

    void mapOnScreen()
    {
        Time.timeScale = 0f;
        bigMap.SetActive(true);
        canvas.SetActive(false);
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        //player.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        AudioListener.pause = true;

    }

    public void downMap()
    {

        Time.timeScale = 1f;
        bigMap.SetActive(false);
        isPaused = false;
        canvas.SetActive(true);
        canvas1.SetActive(true); 
        canvas2.SetActive(true);
        //player.SetActive(true);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        AudioListener.pause = false;
    }

    /*void OnSceneLoaded(Scene scene, LoadSceneMode mode) //recupera riferimento al player quando la scena si carica
    {
        if (player == null && scene.name.Equals("Scena_Principale"))
        {
            player = GameObject.Find("Player");
        }
            
    }*/
}
