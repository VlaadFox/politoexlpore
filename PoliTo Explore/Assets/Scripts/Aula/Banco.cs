using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banco : MonoBehaviour
{

    [SerializeField] private Mesh _banco;
    [SerializeField] private Mesh _sedia;
    [SerializeField] private Mesh _bancoEsedia;
   
    [SerializeField] private Material _bancoMat;
    [SerializeField] private Material _sediaMat;
    [SerializeField] private Material _bancoEsediaMat;

    private Mesh _original;
    private Material _originalMat;
    private bool _bancoAperto= false;
    private bool _sediaAperto = false;
    // Start is called before the first frame update
    void Start()
    {
        _original = GetComponent<MeshFilter>().mesh;
        _originalMat = GetComponent<Renderer>().material;
    }

    public void ApriBanco()
    {
        if (!_bancoAperto)
         {
            GetComponent<MeshFilter>().mesh = _sediaAperto ? _bancoEsedia : _banco;
            GetComponent<Renderer>().material = _sediaAperto ? _bancoEsediaMat : _bancoMat;
            _bancoAperto = true;
        }
    }
    public void ChiudiBanco()
    {
        if (_bancoAperto)
        {
            GetComponent<MeshFilter>().mesh = _sediaAperto? _sedia : _original;
            GetComponent<Renderer>().material = _sediaAperto ? _sediaMat : _originalMat;
            _bancoAperto = false;
        }
    }

    public void ApriSedia()
    {
        if (!_sediaAperto)
        {
            GetComponent<MeshFilter>().mesh = _bancoAperto ? _bancoEsedia : _sedia;
            GetComponent<Renderer>().material = _bancoAperto ? _bancoEsediaMat : _sediaMat;
            _sediaAperto = true;
        }
    }

    public void ChiudiSedia()
    {
        if (_sediaAperto)
        {
            GetComponent<MeshFilter>().mesh = _bancoAperto ? _banco : _original;
            GetComponent<Renderer>().material = _bancoAperto ? _bancoMat : _originalMat;
            _sediaAperto = false;
        }
    }

}
