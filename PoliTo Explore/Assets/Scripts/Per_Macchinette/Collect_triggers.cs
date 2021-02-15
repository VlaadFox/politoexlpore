using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect_triggers : MonoBehaviour
{
    public AudioSource collectSound;

    public GameObject uIObject, scritta;
    Animator scrittaM;
    public bool start = false;
    void Start()
    {
        uIObject.SetActive(false);

        scrittaM = scritta.GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            collectSound.Play();
            Scoring_system.theScore += 1;
            uIObject.SetActive(true);
            StartCoroutine("Wait");
            Create(true);

        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        uIObject.SetActive(false);
        //Destroy(uIObject);
        Destroy(gameObject);

    }
    void Create(bool state)
    {
        scrittaM.SetBool("slide", state);

    }
}