using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cestino : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COllisione");
        if (other.gameObject.GetComponent<Grabbable>() != null)
        {
            Debug.Log("COllisione con grabbable");
            Destroy(other.gameObject);

            //animazione esultanza degli studenti
        }
    }
        // Start is called before the first frame update
        void Start()
    {
        
    }

 
}
