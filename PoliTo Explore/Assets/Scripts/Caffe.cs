using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caffe : PhysicsGrabbable
{
    // Start is called before the first frame update
    public override void Grab(GameObject grabber)
    {
        _collider.enabled = false;
        _rigidbody.isKinematic = true;
        grabber.GetComponent<PlayerController>().walkSpeed = 5f;
        Debug.Log("velocita' aumentata");
    }
}
