using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoMaterie : Interactable
{
    [SerializeField] private GameObject Immagine;
    //[SerializeField] private FPSInteractionManager _intManager;
    private bool _immagineAperta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && _immagineAperta)
        {
            ChiudiImmagine();
        }
    }

    public override void Interact(GameObject caller)
    {
        ApriImmagine();
    }

    public void ApriImmagine()
    {
        _immagineAperta = true;
        Immagine.SetActive(_immagineAperta);         //far apparire l'immagine

       
        Debug.Log("Interazione bacheca materie, apparizione immagine");
    }

    public void ChiudiImmagine()
    {

        //Far scomparire l'immagine
    
        _immagineAperta = false;
        Immagine.SetActive(_immagineAperta);
        Debug.Log("l'immagine sparisce");
    }
}
