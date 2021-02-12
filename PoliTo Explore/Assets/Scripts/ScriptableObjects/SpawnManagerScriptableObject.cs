using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    
    public Spawner[] spawnPoints;
    public GameObject[] objectsToSpawn;


   

    public void OnEnable()
    {
        Debug.Log("OnEnable");
        spawnPoints = GameObject.FindObjectsOfType<Spawner>();
        Debug.Log($"Numero di Spawner (scriptable enable):{ spawnPoints.Length}");
    }

    public void Awake()
    {
        Debug.Log("Awake");
    }

    public Spawner[] GetSpawners()
    {
        if(spawnPoints.Length == 0 || spawnPoints[0] == null)
        {
           spawnPoints = GameObject.FindObjectsOfType<Spawner>();
            Debug.Log("uno era nullo, ricerca spawners");
        }
        Debug.Log($"Numero di Spawner (scriptable get):{ spawnPoints.Length} ,    {spawnPoints[0]}");
        return spawnPoints;
    }

    public GameObject[] GetObjectsToSpawn()
    {
        return objectsToSpawn;
    }
}