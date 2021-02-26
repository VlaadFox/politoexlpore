using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AulaRandomiser : MonoBehaviour
{
    [SerializeField] private float _probBancoA = 0.5f;
    [SerializeField] private float _probStudente = 0.5f;

    public Banco[] banchi;
    [SerializeField] private SpawnManagerScriptableObject SpawnManager;
    [SerializeField] private GameObject Cattedra;
    public GameObject[] Libri;
    public GameObject Penne;

    public Transform PlayerStartPos;

    private GameObject[] _objectsToSpawn;


    void Start()
    {
        GameObject.Find("Player").transform.position= PlayerStartPos.position;
        banchi = GameObject.FindObjectsOfType<Banco>();
        _objectsToSpawn = SpawnManager.GetObjectsToSpawn();
        
        RandomiseStudents();
        Randomise();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Randomise();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChiudiTutto();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            ApriTutto();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
           RandomiseStudents();
        }
        
    }
    
    public void RandomiseStudents()
    {
        foreach (Banco b in banchi)
        {
            if (Random.Range(0.0f, 10.0f)* Vector3.Distance(Cattedra.transform.position, b.transform.position) < _probStudente*65)
            {
                int _index = Random.Range(0, _objectsToSpawn.Length - 1);
                GameObject go = Instantiate(_objectsToSpawn[_index]);

                Vector3 posStud = new Vector3(b.transform.position.x, b.transform.position.y, b.transform.position.z + 0.70281f - 0.2f);
                go.transform.position = posStud; 
                b.ApriSedia();
            }
            
        }

    }

    private void Randomise()
    {

        foreach (Banco b in banchi)
        {
            if (Random.Range(0.0f, 1.0f) < _probBancoA)
            {
                b.ApriBanco();
                int _index = Random.Range(0, Libri.Length - 1);
                GameObject _libro = Instantiate(Libri[_index]);
                Vector3 pos = new Vector3(b.transform.position.x + 0.09534311f, b.transform.position.y + 1.061605f, b.transform.position.z - 0.01986122f);
                _libro.transform.position = pos;

                GameObject _penna = Instantiate(Penne);
                pos = new Vector3(b.transform.position.x - 0.1298752f, b.transform.position.y + 1.053005f, b.transform.position.z - 0.06088066f);
                _penna.transform.rotation *= Quaternion.AngleAxis(Random.Range(-100, 100), Vector3.up);
                _penna.transform.position = pos;
                
            }
        }
    }

 

    private void ApriTutto() //Boris reference?
    {
        foreach (Banco b in banchi)
        {
            b.ApriBanco();
            b.ApriSedia();
        }
    }

    private void ChiudiTutto() 
    { 
        foreach (Banco b in banchi)
        {
            b.ChiudiBanco();
            b.ChiudiSedia();
        }
    }

   
}
