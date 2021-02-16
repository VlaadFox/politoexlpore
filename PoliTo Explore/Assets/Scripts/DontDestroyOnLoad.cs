using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DontDestroy");
        GameObject[] objs2 = GameObject.FindGameObjectsWithTag("Player");

        foreach(GameObject go in objs)
        {
            DontDestroyOnLoad(go);
        }
        foreach (GameObject go in objs2)
        {
            DontDestroyOnLoad(go);
        }

    }

 
}
