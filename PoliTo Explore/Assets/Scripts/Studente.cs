using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Studente : MonoBehaviour

{
    [SerializeField] private int _NofSpawnpoints;
    private List<Spawner> _spawnpoints;
    private int index;

    private UnityEngine.AI.NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        
        Spawner[] _array = GameObject.FindObjectsOfType<Spawner>();
        _spawnpoints = new List<Spawner>(_array);
        
        if (_NofSpawnpoints != _spawnpoints.Count)
        {
            Debug.Log("Problema con gli spawner");
            Debug.Log($"Numero di Spawner:{ _spawnpoints.Count}");
        }

        SetDestination();


    }

    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity.sqrMagnitude <= 0f){
            Destroy(this.gameObject);
        }

    }

    public void SpawnStudent()
    {

    }

    public void SetDestination()
    {
        
        index = Random.Range(0, _spawnpoints.Count - 1);
        if(_spawnpoints[index] != null)
        {
            Vector3 wayPointPos = _spawnpoints[index].transform.position;
            _navMeshAgent.SetDestination(new Vector3(wayPointPos.x, transform.position.y, wayPointPos.z));
        }
         
    }
    
}
