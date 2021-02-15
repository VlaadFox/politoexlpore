using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Discoverable : Interactable
{
    public Grabbable ObjectToSpawn;
    void Start()
    {

    }

    public override void Interact(GameObject caller)
    {
        Vector3 pos = this.transform.Find("drop").transform.position;
        Grabbable go = Instantiate(ObjectToSpawn);
        go.transform.position = pos;
        go.GetComponent<Rigidbody>().isKinematic = true;
    }
}
