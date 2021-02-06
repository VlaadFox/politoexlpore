using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_door : MonoBehaviour
{

    public GameObject movingDoor;

    public float maximumOpening = 1f;
    public float maximumClosing = 0f;

    public float movementSpeed = 1f;

    bool playerIsHere;

    // Start is called before the first frame update
    void Start()
    {
        playerIsHere = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsHere)
        {
            if (movingDoor.transform.position.x < maximumOpening)
            {
                movingDoor.transform.Translate(movementSpeed * Time.deltaTime, 0f, 0f);
                if (movingDoor.transform.position.x == maximumOpening) {
                    movingDoor.transform.Translate(0f, 0f, 0f);
                }
            }
        }
        else
        {
            if (movingDoor.transform.position.x > maximumClosing)
            {
                movingDoor.transform.Translate(-movementSpeed * Time.deltaTime, 0f, 0f);
            }
        }


    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsHere = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            playerIsHere = false;
        }
    }
}
