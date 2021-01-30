using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cestino : MonoBehaviour
{
     public EventsManager eventsManager;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collisione");
        if (other.gameObject.GetComponent<Grabbable>() != null)
        {
            Debug.Log("Collisione con grabbable");
            Destroy(other.gameObject);

            eventsManager.OnCanestro();
        }
    }
        // Start is called before the first frame update
    void Start()  {
        if(eventsManager == null){
            eventsManager = GameObject.FindObjectOfType<EventsManager>();
        }    
    }

 
}
