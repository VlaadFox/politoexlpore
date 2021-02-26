using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Macchinette1 : MonoBehaviour
{
    private static Macchinette1 _instance;

    public static Macchinette1 Instance { get { return _instance; } }


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
