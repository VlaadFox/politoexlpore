using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class New_Auto_door : MonoBehaviour
{
    public GameObject trigger, leftDoor, rightDoor;
    public AudioSource collectSound;

    Animator leftAnim, rightAnim;
    void Start()
    {
        leftAnim = leftDoor.GetComponent<Animator>();
        rightAnim = rightDoor.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Studenti")
        {
            SlideDoors(true);
            collectSound.Play();
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.tag == "Player" || coll.gameObject.tag == "Studenti")
        {
            SlideDoors(false);
           collectSound.Play();
        }
    }

    void SlideDoors(bool state)
    {
        leftAnim.SetBool("slide", state);
        rightAnim.SetBool("slide", state);

    }

}
