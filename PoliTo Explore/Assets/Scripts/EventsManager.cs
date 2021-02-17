using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventsManager : MonoBehaviour

{
    public event Action canestroEvent;
    public event Action loadAula1Event;
    public event Action loadAula2Event;
    public event Action loadPrincipaleEvent;



    public void OnCanestro()
    {
        if (canestroEvent != null)
        {
            canestroEvent.Invoke();
        }
    }
    public void LoadAula1()
    {
        if (loadAula1Event != null)
        {
            loadAula1Event.Invoke();
        }
    }

    public void LoadAula2()
    {
        if (loadAula2Event != null)
        {
            loadAula2Event.Invoke();
        }
    }

    public void loadPrincipale()
    {
        if (loadPrincipaleEvent != null)
        {
            loadPrincipaleEvent.Invoke();
        }
    }





}
