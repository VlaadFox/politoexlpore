using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCsSpawnManager : MonoBehaviour

   
{

    [SerializeField] private SpawnManagerScriptableObject SpawnManager;

    private Spawner[] _spawners;
    private GameObject[] _objectsToSpawn;

    // Start is called before the first frame update
    void Start() {
        _spawners = SpawnManager.GetSpawners();
        _objectsToSpawn = SpawnManager.GetObjectsToSpawn();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.E))    {
            SpawnStudents();
        }
      
    }

    public void SpawnStudents()
    {
        for(int i=0; i< _spawners.Length; i++)
        {
            int _index = Random.Range(0, _objectsToSpawn.Length - 1);
            GameObject go = Instantiate(_objectsToSpawn[_index]);
            go.transform.position = _spawners[i].transform.position;
        }
        
    }
}
