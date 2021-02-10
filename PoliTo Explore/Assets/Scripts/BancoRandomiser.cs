using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoRandomiser : MonoBehaviour
{
    [SerializeField] private float _probBancoA = 0.5f;
    private Banco[] _banchi;
    // Start is called before the first frame update
    void Start()
    {
        _banchi = GameObject.FindObjectsOfType<Banco>();

        foreach (Banco b in _banchi)
        {
            if(Random.Range(0.0f, 1.0f) < _probBancoA)
            {
                b.ApriBanco();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
