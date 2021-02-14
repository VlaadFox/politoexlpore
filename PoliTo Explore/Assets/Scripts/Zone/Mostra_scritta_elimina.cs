using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mostra_scritta_elimina : MonoBehaviour
{
    public GameObject uIObject, scritta;
    Animator scrittaM;
    public bool start = false;
    void Start()
    {
        uIObject.SetActive(false);

        scrittaM = scritta.GetComponent<Animator>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            uIObject.SetActive(true);
            StartCoroutine("Wait");
            Create(true);
            
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(4);
        uIObject.SetActive(false);
        Destroy(uIObject);
        Destroy(gameObject);

    }
    void Create(bool state)
    {
        scrittaM.SetBool("slide", state);

    }

}
