using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ExplorationDataScriptableObject", order = 1)]
public class ExplorationDataScriptableObject : ScriptableObject
{


    public void OnEnable()
    {
        Debug.Log("OnEnable");
        
    }

    public void Awake()
    {
        Debug.Log("Awake");
    }
}