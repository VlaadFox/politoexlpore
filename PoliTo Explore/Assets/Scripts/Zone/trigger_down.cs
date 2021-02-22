using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger_down : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {

           this.gameObject.SetActive(false);
        }
    }
}
