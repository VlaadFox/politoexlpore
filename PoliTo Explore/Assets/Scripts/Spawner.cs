using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private SpawnManagerScriptableObject SpawnManager;

    private GameObject[] _objectsToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        //_objectsToSpawn = SpawnManager.objectsToSpawn
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            //SpawnStudent();
        }
    }

    public void SpawnStudent()
    {
       
        int _index = Random.Range(0, SpawnManager.objectsToSpawn.Length - 1);
        GameObject go = Instantiate(SpawnManager.objectsToSpawn[_index]);
        go.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
        go.GetComponent<UnityEngine.AI.NavMeshAgent>().updatePosition = false;
        go.transform.position = transform.position;
   
    }


}
