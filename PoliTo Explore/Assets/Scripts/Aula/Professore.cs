using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Professore : MonoBehaviour
{

    private Animator _animator;
    float cont = 3.733f;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimations();
    }

    private void UpdateAnimations()
    {
        
        if (cont > 0f)
        {
            _animator.SetBool("talk", false);
            cont -= Time.deltaTime;
        }
        else
        {
            _animator.SetBool("talk", true);
            cont = 3.733f;
        }
    }
}
