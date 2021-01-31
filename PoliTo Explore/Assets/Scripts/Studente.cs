﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Studente : MonoBehaviour

{
    [SerializeField] private int _NofSpawnpoints;
    [SerializeField] private SpawnManagerScriptableObject SpawnManager;
    public EventsManager eventsManager;

    private Spawner[] _spawnpoints;
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private int _index;
    private float _speed;


    // Start is called before the first frame update
    void Start()
    {
        if (eventsManager == null) {
            eventsManager = GameObject.FindObjectOfType<EventsManager>();
        }
        eventsManager.canestroEvent += Cheer;
        _animator = GetComponent<Animator>();

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
            //TODO: dovrebbe spawnarne un altro dalla stessa posizione
        }
        UpdateAnimations();

    }

    private void Cheer()
    {
        //animazione di gioia
        Debug.Log("Lo studente esulta");
        _animator.SetBool("clapping", true);
    }

    private void UpdateAnimations()
    {
        int cont = 0;
        _speed = Mathf.Clamp(_navMeshAgent.desiredVelocity.magnitude, 0f, 1f);
        _animator.SetFloat("clapping", _speed);
        //Debug.Log($"Velocity:  {_navMeshAgent.desiredVelocity}");
        if (_animator.GetBool("clapping"))  {
            if (cont < 10){
                cont++;
            }else {
                _animator.SetBool("clapping", false);
                cont = 0;
            }
        }

    }
   

    public void SetDestination()
    {
        
        _index = Random.Range(0, _spawnpoints.Length - 1);
        Debug.Log($"Navigando allo spowner {_index} alla posizione {_spawnpoints[_index]}");
        if (_spawnpoints[_index] != null)
        {
            Vector3 wayPointPos = _spawnpoints[_index].transform.position;
            //_navMeshAgent.SetDestination(new Vector3(wayPointPos.x, transform.position.y, wayPointPos.z));
            _navMeshAgent.SetDestination(wayPointPos);
           
        }
         
    }
    
}
