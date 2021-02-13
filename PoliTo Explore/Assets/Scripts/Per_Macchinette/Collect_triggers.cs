using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_triggers : MonoBehaviour
{
    public AudioSource collectSound;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            collectSound.Play();
            Scoring_system.theScore += 1;
            Destroy(gameObject);
        }
    }
}
