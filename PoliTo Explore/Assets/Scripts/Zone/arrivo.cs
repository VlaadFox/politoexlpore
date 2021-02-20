using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrivo : MonoBehaviour
{
    public GameObject trigger, arrow;
    void Start()
    {
        trigger.SetActive(false);
        arrow.SetActive(false);
    }

    public void OnTriggerEvent(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            StartCoroutine("Wait");
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        trigger.SetActive(false);
        arrow.SetActive(false);
       
    }

    public void setActive()
    {
        trigger.SetActive(true);
    }
}
