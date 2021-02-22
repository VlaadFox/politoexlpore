using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrivo : MonoBehaviour
{
    public GameObject arrow; 
    public GameObject[] triggers;
    private GameObject tri;
    //private List<GameObject> tris = new List<GameObject>();


    void Start()
    {
       //trigger.SetActive(false);
      // arrow.SetActive(false);
    }

    public void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            
            //tri.SetActive(false);
            /*foreach(GameObject tt in tris)
            {
                tt.SetActive(false);
                Debug.Log("disattivato");
            }*/
            arrow.SetActive(false);
            //StartCoroutine("Wait");
        }
    }
    
   /*IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.1f);
        trigger.SetActive(false);
        arrow.SetActive(false);
       
    }*/

    public void Set(GameObject trigger)
    {

            //       pv.SetFollow(trigger);

            for (int i = 0; i < triggers.Length; i++) { 
                if(trigger.transform == triggers[i].transform && !arrow.activeSelf) {

                //     GameObject tri = trigger;
                // if (!tris.Contains(tri)) {
                //tris.Add(tri);
                //}
                tri = trigger;
                arrow.SetActive(true);
                arrow.GetComponent<Prova>().SetFollow(tri);
                tri.SetActive(true);
                
            }
        }
    }
}
