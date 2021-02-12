using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudenteAula : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;

    private int _index;
    private AulaRandomiser _randomiz;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDestination()
    {

        _index = Random.Range(0, _randomiz.banchi.Length - 1);
        Debug.Log($"Navigando allo spowner {_index} alla posizione {_randomiz.banchi[_index]}");
        if (_randomiz.banchi[_index] != null)
        {
            Vector3 wayPointPos = _randomiz.banchi[_index].transform.position;
            //_navMeshAgent.SetDestination(new Vector3(wayPointPos.x, transform.position.y, wayPointPos.z));
            _navMeshAgent.SetDestination(wayPointPos);

        }

    }

}

