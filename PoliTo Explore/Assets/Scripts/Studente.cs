using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Studente : MonoBehaviour

{
    [SerializeField] private int _NofSpawnpoints;
    [SerializeField] private SpawnManagerScriptableObject SpawnManager;
    public EventsManager eventsManager;

    // private List<Spawner> _spawnpoints;
    private Spawner[] _spawnpoints;
    private int index;

    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    

    // Start is called before the first frame update
    void Start()
    {
        if (eventsManager == null) {
            eventsManager = GameObject.FindObjectOfType<EventsManager>();
        }
        eventsManager.canestroEvent += Cheer;

        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();

        _spawnpoints = SpawnManager.GetSpawners();
        Debug.Log(_spawnpoints[1]);
        //_spawnpoints = new List<Spawner>(_array);

        if (_NofSpawnpoints != _spawnpoints.Length){
            Debug.Log("Problema con gli spawner");
            Debug.Log($"Numero di Spawner:{ _spawnpoints.Length}");
        }

        SetDestination();
    }

    // Update is called once per frame
    void Update()
    {
        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity.sqrMagnitude <= 0.5f){
            Debug.Log("Arrivato a destinazione, autodistruzione");
            Destroy(this.gameObject);
        }

    }

    private void Cheer()
    {
        //animazione di gioia
        Debug.Log("Lo studente esulta");
    }

    public void SpawnStudent()
    {

    }

    public void SetDestination()
    {
        
        index = Random.Range(0, _spawnpoints.Length - 1);
        Debug.Log($"Navigando allo spowner {index} alla posizione {_spawnpoints[index]}");
        if (_spawnpoints[index] != null)
        {
            Vector3 wayPointPos = _spawnpoints[index].transform.position;
            //_navMeshAgent.SetDestination(new Vector3(wayPointPos.x, transform.position.y, wayPointPos.z));
            _navMeshAgent.SetDestination(wayPointPos);
           
        }
         
    }
    
}
