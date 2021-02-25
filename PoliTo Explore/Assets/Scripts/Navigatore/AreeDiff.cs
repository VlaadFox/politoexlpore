using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreeDiff : MonoBehaviour
{
    private static AreeDiff _instance;

    public static AreeDiff Instance { get { return _instance; } }


    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            //Debug.Log($"Distrutto player nella posizione {this.transform.position}");
        }
        else
        {
            _instance = this;
        }
    }
}
