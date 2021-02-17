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

    static EventsManager singleton;
    // Start is called before the first frame update
    void Start()
    {
        if (singleton != null)
        {
            Destroy(this.gameObject);
            return;
        }
        singleton = this;

    }

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

    public void LoadPrincipale()
    {
        if (loadPrincipaleEvent != null)
        {
            loadPrincipaleEvent.Invoke();
        }
    }





}
