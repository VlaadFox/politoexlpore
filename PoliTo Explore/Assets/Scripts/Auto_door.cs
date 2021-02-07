using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_door : MonoBehaviour
{
    public GameObject trigger, leftDoor, rightDoor;

    Animator leftAnim, rightAnim;
    void Start()
    {
        leftAnim = leftDoor.GetComponent<Animator>();
        rightAnim = rightDoor.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            SlideDoors(true);
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            SlideDoors(false);
        }
    }

    void SlideDoors(bool state)
    {
        leftAnim.SetBool("slide", state);
        rightAnim.SetBool("slide", state);

    }

}
