using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScenesManager : MonoBehaviour
{

    [SerializeField] private EventsManager eventsManager;
    [SerializeField] private GameObject player;
    private Vector3 _playerPos;
    private Quaternion _playerRot;
    //private Quaternion _playerRot;

    private static ScenesManager _instance;
    public static ScenesManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }

        
    }
    void Start()
    {
        //if(singleton != null)
        //{
        //    Destroy(this.gameObject);
        //    return;
        //}
        //singleton = this;

        

        player = GameObject.Find("Player");

        eventsManager.loadAula1Event += LoadAula1;
        eventsManager.loadAula2Event += LoadAula2;
        eventsManager.loadPrincipaleEvent += LoadPrincipale;
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    public void LoadAula1()
    {
        _playerPos = player.transform.position - player.transform.forward;
        _playerRot = player.transform.rotation *= Quaternion.AngleAxis(90f, Vector3.up);
        Debug.Log($"posizione reale: {player.transform.position}");
        Debug.Log($"posizione salvata: {_playerPos}");
        SceneManager.LoadScene("Aula_1porta", LoadSceneMode.Single);
        //Debug.Log($"dopo it caricamento1: {_playerPos}");
        
    }

    public void LoadAula2()
    {
        _playerPos = player.transform.position - player.transform.forward;
        _playerRot = player.transform.rotation *= Quaternion.AngleAxis(90f, Vector3.up);
        SceneManager.LoadScene("Aula_3porte", LoadSceneMode.Single);
    }

    public void LoadPrincipale()
    {
        //Debug.Log($"primad el caricamento2: {_playerPos}");
        SceneManager.LoadScene("Scena_Principale", LoadSceneMode.Single);
        //Debug.Log($"posizione ruotata: {_playerPos}");
        player.transform.SetPositionAndRotation(_playerPos, _playerRot);
        //Debug.Log($"posizione settata: {player.transform.position}");
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Scena_Principale" && _playerPos != null)
        {
            player.transform.SetPositionAndRotation(_playerPos, _playerRot);
            Debug.Log($"posizione settata: {player.transform.position}");
            Debug.Log("OnSceneLoaded: " + scene.name);
        }
    }

}
