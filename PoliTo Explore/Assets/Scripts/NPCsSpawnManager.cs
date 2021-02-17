using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsSpawnManager : MonoBehaviour

   
{

    [SerializeField] private SpawnManagerScriptableObject SpawnManager;

    private Spawner[] _spawners;
    private GameObject[] _objectsToSpawn;
    private float _spawnTime = 2.0f;
    private int _spawnNumber = 3;
    private float count = 0f;
    private int countInt = 0;


    // Start is called before the first frame update
    void Start() {
        _spawners = SpawnManager.GetSpawners();
        _objectsToSpawn = SpawnManager.GetObjectsToSpawn();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.P))    {
            SpawnStudents();
        }
        //if(countInt <_spawnNumber){
        //    if (count < _spawnTime)
        //        count += Time.deltaTime;
        //    else{
        //        SpawnStudents();
        //        countInt++;
        //        count = 0f;
        //    }

        //}
      
    }

    public void SpawnStudents()
    {
        for(int i=0; i< _spawners.Length; i++)
        {
            int _index = Random.Range(0, _objectsToSpawn.Length - 1);
            GameObject go = Instantiate(_objectsToSpawn[_index]);
            go.GetComponent<UnityEngine.AI.NavMeshAgent>().isStopped = true;
            go.GetComponent<UnityEngine.AI.NavMeshAgent>().updatePosition = false;
            go.GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(_spawners[i].transform.position);
            //go.transform.position = _spawners[i].transform.position;
        }
        
    }
}
