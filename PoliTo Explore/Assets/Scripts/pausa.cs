using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausa : MonoBehaviour
{
    public static bool GiocoInPausa = false;
    public GameObject pauseMenuUI;
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GiocoInPausa)
            {
                Resume();
            }
            else {
                Pause();
            }
        } 
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GiocoInPausa = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GiocoInPausa = true;
    }
}
