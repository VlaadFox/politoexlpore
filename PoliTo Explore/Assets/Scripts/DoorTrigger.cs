using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Door _door;
    [SerializeField] private bool _openOnEnter = true;
    [SerializeField] private bool _closeOnExit = true;

    [SerializeField] private Scene Scene;
    private void OnTriggerEnter(Collider other)
    {
        Vector3 othersPositionRelativeToDoor = (other.transform.position - transform.position).normalized;
        
        //the result of the dot product returns > 0 if relative position 
        float dotResult = Vector3.Dot(othersPositionRelativeToDoor, transform.forward);
        

        float doorRotation = dotResult > 0 ? 90f : -90f;

        if (_door != null && _openOnEnter)
            _door.OpenDoor(doorRotation);

        if (other.gameObject.GetComponent<PlayerController>() != null)
        {
            //StartCoroutine(LoadYourAsyncScene());
            SceneManager.LoadScene("Aula_1porta", LoadSceneMode.Single);
        }

        Debug.Log("Entrato nell'area della porta");
    }

    private void OnTriggerExit(Collider other)
    {
        if (_door != null && _closeOnExit)
            _door.CloseDoor();
        Debug.Log("Uscito dall'area della porta");
    }

    IEnumerator LoadYourAsyncScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Aula_1porta");

        
        while (!asyncLoad.isDone)
        {
            yield return null;
            Debug.Log("Caricamento Scena");
        }
    }
}
