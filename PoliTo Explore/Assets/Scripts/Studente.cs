using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Studente : MonoBehaviour

{
    [SerializeField] private int _NofSpawnpoints;
    [SerializeField] private SpawnManagerScriptableObject SpawnManager;
    private float cheerAnimationTime = 3.70f;

    public EventsManager eventsManager;


    private Spawner[] _spawnpoints;
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private AudioSource[] sounds;
    private AudioSource clap;

    private int _index;
    private float _speed;
    private float _animationCounter;



    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        clap = sounds[0];

        _animator = GetComponent<Animator>();
        //Debug.Log("Scena di appartenenza: " + this.gameObject.scene.name);
        if (this.gameObject.scene.name.Equals("Scena_Principale"))
        {
            if (eventsManager == null)
            {
                eventsManager = GameObject.FindObjectOfType<EventsManager>();
                //Debug.Log($"Event Manager:{eventsManager}");
            }
            eventsManager.canestroEvent += Cheer;
            

            _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
            //Debug.Log($"NavMeshAgent:{_navMeshAgent}");

            _spawnpoints = SpawnManager.GetSpawners();
            //Debug.Log(_spawnpoints[1]);

            if (_NofSpawnpoints != _spawnpoints.Length)
            {
                Debug.Log("Problema con gli spawner");
                Debug.Log($"Numero di Spawner:{ _spawnpoints.Length}");
            }

            SetDestination();

        }
        else
        {
            Debug.Log(this.transform.Find("mixamorig:Hips/mixamorig:Spine/Zaino"));
            Destroy(this.transform.Find("mixamorig:Hips/mixamorig:Spine/Zaino"));
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
        if (this.gameObject.scene.name.Equals("Scena_Principale"))
        {

            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity.sqrMagnitude <= 0.5f)
            {
                Debug.Log("Arrivato a destinazione, autodistruzione");
                _spawnpoints[_index].SpawnStudent();
                Destroy(this.gameObject);
                //TODO: dovrebbe spawnarne un altro dalla stessa posizione
            }
        }
    }

    private void Cheer()
    {

        //Debug.Log("Lo studente esulta");
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
        if (this.gameObject.scene.name.Equals("Scena_Principale"))
        {

            _speed = Mathf.Clamp(_navMeshAgent.desiredVelocity.magnitude, 0f, 1f);
            _animator.SetFloat("speed", _speed);
            if (_animator.GetBool("clapping"))
            {
                //Debug.Log($"Tempo mancante aninazione:  {_animationCounter}");
                if (_animationCounter > 0f)
                {

                    _animationCounter -= Time.deltaTime;
                }
                else
                {
                    _animator.SetBool("clapping", false);
                    _navMeshAgent.isStopped = false;
                    _animationCounter = cheerAnimationTime;
                }
            }
        }
        else{
            _animator.SetBool("sit", true);
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
