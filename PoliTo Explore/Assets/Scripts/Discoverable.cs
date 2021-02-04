using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discoverable : Interactable
{
    public ExplorationDataScriptableObject Data;
    void Start()
    {
        if(Data == null) {
            Data = GameObject.FindObjectOfType<ExplorationDataScriptableObject>();
        }
    }
    
public override void Interact(GameObject caller)
    {
        //Data.AddDiscovered(gameObject);
        Debug.Log(Data.AddDiscovered(gameObject));

        //TODO: messaggio a schermo con numero di cose scoperte
    }
}
