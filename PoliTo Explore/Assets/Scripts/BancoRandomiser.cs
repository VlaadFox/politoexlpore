using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BancoRandomiser : MonoBehaviour
{
    [SerializeField] private float _probBancoA = 0.5f;
    [SerializeField] private float _probSediaA = 0.5f;
    public Banco[] banchi;
    // Start is called before the first frame update
    void Start()
    {
        banchi = GameObject.FindObjectsOfType<Banco>();
        //Randomise();
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
    }

    private void Randomise()
    {

        foreach (Banco b in banchi)
        {
            if (Random.Range(0.0f, 1.0f) < _probBancoA)
            {
                b.ApriBanco();
            }
            if (Random.Range(0.0f, 1.0f) < _probSediaA) //messo per prova, penso vada tolto
            {
                b.ApriSedia();
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
