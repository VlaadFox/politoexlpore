using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsManager : MonoBehaviour

{
    public event Action canestroEvent;


    public void OnCanestro()
    {
        if (canestroEvent != null) {
            canestroEvent.Invoke();
        }
    }



}
