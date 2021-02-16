﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform playerCamera = null;
    [SerializeField] float mouseSensitivity = 3.5f;
    [SerializeField] float walkSpeed = 6.0f;
    [SerializeField] float gravity = -13.0f;

    [SerializeField] [Range(0.0f, 0.5f)] float moveSmoothTime = 0.15f;
    [SerializeField] [Range(0.0f, 0.5f)] float mouseSmoothTime = 0.01f;

    [SerializeField] bool lockCursor = true;

    public GameObject miniMap, bigMap, handGrab, text;
   

    float cameraPitch = 0.0f;
    float velocityY = 0.0f;

    CharacterController controller = null;
    Vector2 currentDir = Vector2.zero;
    Vector2 currentDirVelocity = Vector2.zero;

    Vector2 currentMouseDelta = Vector2.zero;
    Vector2 currentMouseDeltaVelocity = Vector2.zero;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void Update()
    {
        UpdateMouseLook();
        UpdateMovement();

        if (Input.GetKeyDown(KeyCode.M))
        {
            if (bigMap.active) { downMap(); }
            else
            { mapOnScreen();
               }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (bigMap.active) { downMap(); }
        }

        /*if (Input.GetKeyDown(KeyCode.Escape))
        {   

            SceneManager.LoadSceneAsync("Menu");
            //PauseGame();


        }*/

    }
    /*public void PauseGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
      
    }*/

    void UpdateMouseLook()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        cameraPitch -= currentMouseDelta.y * mouseSensitivity;

        cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMovement()
    {

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        if (controller.isGrounded)
            velocityY = 0.0f;
        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * walkSpeed + Vector3.up * velocityY;
      

        controller.Move(velocity * Time.deltaTime);
    }

    void downMap()
    {
        bigMap.SetActive(false);
        Time.timeScale = 1f;
        miniMap.SetActive(true);
        handGrab.SetActive(true);
        text.SetActive(true);
    }
    void mapOnScreen()
    {
        bigMap.SetActive(true);
        Time.timeScale = 0.02f;
        miniMap.SetActive(false);
        handGrab.SetActive(false);
        text.SetActive(false);
    }
}
