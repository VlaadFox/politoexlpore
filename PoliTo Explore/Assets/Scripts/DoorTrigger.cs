using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private bool _openOnEnter = true;
    [SerializeField] private bool _closeOnExit = true;

    [SerializeField] private EventsManager eventsManager;
    [SerializeField] private bool portaSingola;
    [SerializeField] private bool portaInternoAula;

    void Start()
    {
        if (eventsManager == null)

            eventsManager = GameObject.FindObjectOfType<EventsManager>();
    }
        private void OnTriggerEnter(Collider other)
    {
        //Vector3 othersPositionRelativeToDoor = (other.transform.position - transform.position).normalized; 
        //float dotResult = Vector3.Dot(othersPositionRelativeToDoor, transform.forward);
        //float doorRotation = dotResult > 0 ? 90f : -90f;

        float doorRotation = 90f;

        if (_door != null && _openOnEnter)
            _door.OpenDoor(doorRotation);

        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            if (!portaInternoAula)
            {
                if (portaSingola)
                {
                    eventsManager.LoadAula1();
                }
                else
                {
                    eventsManager.LoadAula2();
                }
            }
            else
            {
                eventsManager.LoadPrincipale();
            }
            
            
        }

        Debug.Log("Entrato nell'area della porta");
    }

    private void OnTriggerExit(Collider other)
    {
        if (_door != null && _closeOnExit)
            _door.CloseDoor();
        Debug.Log("Uscito dall'area della porta");
    }

    
}
