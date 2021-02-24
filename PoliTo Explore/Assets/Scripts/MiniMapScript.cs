using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapScript : MonoBehaviour{

    //public Transform player;
    private GameObject game = null;
    private void Start()
    {
        game = GameObject.FindGameObjectWithTag("Player");
    }
    void LateUpdate()
    {
        Vector3 newPosition = game.transform.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
    }
}
