using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Studente : MonoBehaviour

{
   
    [SerializeField] private SpawnManagerScriptableObject SpawnManager;
    private float cheerAnimationTime = 3.70f;
    public bool gironzola;

    public EventsManager eventsManager;

    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private AudioSource[] sounds;
    private AudioSource clap;

    private int _index;
    private float _speed;
    private float _animationCounter;
    private Vector3 dest;



    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        clap = sounds[0];


        _animator = GetComponent<Animator>();
        _animationCounter = cheerAnimationTime;

        //Debug.Log("Scena di appartenenza: " + this.gameObject.scene.name);
        if (this.gameObject.scene.name.Equals("Scena_Principale"))
        {
            if (eventsManager == null)
            {
                eventsManager = GameObject.FindObjectOfType<EventsManager>();
                //Debug.Log($"Event Manager:{eventsManager}");
            }
            eventsManager.canestroEvent += Cheer;

            if (!gironzola)
            {
                //Destroy(GetComponent<Rigidbody>());
                _animator.Play("Breathing Idle", 0, Random.Range(0f, 0.5f));
            }
            else
            {
                Rigidbody rb = gameObject.AddComponent<Rigidbody>() as Rigidbody;
                NavMeshAgent nva = gameObject.AddComponent<UnityEngine.AI.NavMeshAgent>() as NavMeshAgent;
                _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
                _navMeshAgent.autoRepath = true;
            }

            //Debug.Log($"NavMeshAgent:{_navMeshAgent}");
            

            if(gironzola)
                SetDestination();



        }
        else
        {
            //Debug.Log(this.transform.Find("mixamorig:Hips/mixamorig:Spine/zaino"));
            //Destroy(this.transform.Find("mixamorig:Hips/mixamorig:Spine/zaino"));
            //Destroy(GetComponent<UnityEngine.AI.NavMeshAgent>());
            //Destroy(GetComponent<Rigidbody>());
            //_animator.SetBool("sit", true);
            _animator.Play("Sit", 0, Random.Range(0f, 0.5f));
        }
        
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.C))
        {
            Cheer();
        }

        
        if (this.gameObject.scene.name.Equals("Scena_Principale"))
        {
            if (gironzola)
            {
                if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && _navMeshAgent.velocity.sqrMagnitude <= 0.5f)
                {
                    SetDestination();   
                }
            }
        }
        UpdateAnimations();
    }


    private void Cheer()
    {
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
            if (_navMeshAgent != null)
                _speed = Mathf.Clamp(_navMeshAgent.desiredVelocity.magnitude, 0f, 1f);

            _animator.SetFloat("speed", _speed);
            if (_animator.GetBool("clapping"))
            { 
                if (_animationCounter > 0f)
                {

                    _animationCounter -= Time.deltaTime;
                }
                else
                {
                    _animator.SetBool("clapping", false);
                    if (_navMeshAgent != null)
                        _navMeshAgent.isStopped = false;

                    _animationCounter = cheerAnimationTime;
                    _animator.Play("Breathing Idle", 0, Random.Range(0f, 0.5f));
                }
            }
        }
        else{
            //_animator.SetBool("sit", true);
        }

    }

    private void OnCollisionEnter() //semplice ed efficace,  non ottimo per le prestazioni
    {
        if (gironzola)
        {
            SetDestination();
        }
            
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float distance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.onUnitSphere * distance;

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);

        return navHit.position;
    }


    public void SetDestination()
    {
       
        dest = RandomNavSphere(transform.position, 20f, 1);
        _navMeshAgent.SetDestination(dest);
                                
        //Debug.Log("nuova destinazione");
        _navMeshAgent.isStopped = false;
        _navMeshAgent.updatePosition = true;
           
        

    }

}
