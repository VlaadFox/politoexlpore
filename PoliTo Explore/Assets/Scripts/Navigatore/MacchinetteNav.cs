using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MacchinetteNav : MonoBehaviour
{
    private static MacchinetteNav _instance;

    public static MacchinetteNav Instance { get { return _instance; } }


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
