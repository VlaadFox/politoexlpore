using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Studente : MonoBehaviour

{
    [SerializeField] private int _NofSpawnpoints;
    [SerializeField] private SpawnManagerScriptableObject SpawnManager;
    [SerializeField] private float cheerAnimationTime = 1.85f;

    public EventsManager eventsManager;


    private Spawner[] _spawnpoints;
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private AudioSource[] sounds;
    private AudioSource clap;

    private int _index;
    private float _speed;
    


    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        clap = sounds[0];

        Debug.Log("Scena di appartenenza: " + this.gameObject.scene.name);
        if (this.gameObject.scene.name.Equals("Scena_Principale")){
            if (eventsManager == null)
            {
                eventsManager = GameObject.FindObjectOfType<EventsManager>();
                //Debug.Log($"Event Manager:{eventsManager}");
            }
            eventsManager.canestroEvent += Cheer;
            _animator = GetComponent<Animator>();

            _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            Debug.Log($"NavMeshAgent:{_navMeshAgent}");

            _spawnpoints = SpawnManager.GetSpawners();
            Debug.Log(_spawnpoints[1]);
            //_spawnpoints = new List<Spawner>(_array);

            if (_NofSpawnpoints != _spawnpoints.Length)
            {
                Debug.Log("Problema con gli spawner");
                Debug.Log($"Numero di Spawner:{ _spawnpoints.Length}");
            }

            SetDestination();

        }
        else
        {
            Destroy(GetComponent<UnityEngine.AI.NavMeshAgent>());
        }
    }
        

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.C))
        {
            Cheer();
            
        }

        UpdateAnimations();

        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity.sqrMagnitude <= 0.5f)
        {
            Debug.Log("Arrivato a destinazione, autodistruzione");
            Destroy(this.gameObject);
            //TODO: dovrebbe spawnarne un altro dalla stessa posizione
        }
    }

    private void Cheer()
    {
        //animazione di gioia
        Debug.Log("Lo studente esulta");
        //Debug.Log(_animator);
        if (_animator != null)
        {
            _animator.SetBool("clapping", true);
            clap.Play();
        }
        if (_navMeshAgent != null)
            _navMeshAgent.isStopped = true;
    }

    private void UpdateAnimations()
    {
        
        _speed = Mathf.Clamp(_navMeshAgent.desiredVelocity.magnitude, 0f, 1f);
        _animator.SetFloat("speed", _speed);
        //Debug.Log($"Velocity:  {_navMeshAgent.desiredVelocity}");
        if (_animator.GetBool("clapping"))  {
            if (cheerAnimationTime > 0f){
                
                cheerAnimationTime -=Time.deltaTime;
            }
            else {
                _animator.SetBool("clapping", false);
                _navMeshAgent.isStopped = false;
                cheerAnimationTime = 1.85f;
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
