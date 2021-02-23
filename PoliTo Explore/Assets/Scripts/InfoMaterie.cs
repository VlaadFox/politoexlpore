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
        if (Input.anyKeyDown && _immagineAperta)
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
        //Immagine.SetActive(true);         //far apparire l'immagine

        _immagineAperta = true;
        Debug.Log("Interazione bacheca materie, apparizione immagine");
    }

    public void ChiudiImmagine()
    {

        //Far scomparire l'immagine
        _immagineAperta = false;
        Debug.Log("l'immagine sparisce");
    }
}
