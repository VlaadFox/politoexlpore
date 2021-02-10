using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banco : MonoBehaviour
{

    [SerializeField] private Mesh _banco;
    [SerializeField] private Mesh _sedia;
    [SerializeField] private Mesh _bancoEsedia;

    private Mesh _original;
    private bool _bancoAperto= false;
    private bool _sediaAperto = false;
    // Start is called before the first frame update
    void Start()
    {
        _original = GetComponent<MeshFilter>().mesh;
        
    }

    public void ApriBanco()
    {
        if (!_bancoAperto)
         {
            GetComponent<MeshFilter>().mesh = _sediaAperto ? _bancoEsedia : _banco;
            _bancoAperto = true;
        }
    }
    public void ChiudiBanco()
    {
        if (_bancoAperto)
        {
            GetComponent<MeshFilter>().mesh = _sediaAperto? _sedia : _original;
            _bancoAperto = false;
        }
    }

    public void ApriSedia()
    {
        if (!_sediaAperto)
        {
            GetComponent<MeshFilter>().mesh = _bancoAperto ? _bancoEsedia : _sedia;
            _sediaAperto = true;
        }
    }

    public void ChiudiSedia()
    {
        if (_sediaAperto)
        {
            GetComponent<MeshFilter>().mesh = _bancoAperto ? _banco : _original;
            _sediaAperto = false;
        }
    }

}
