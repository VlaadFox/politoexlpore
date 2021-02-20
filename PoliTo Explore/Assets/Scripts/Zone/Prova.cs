using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prova : MonoBehaviour
{
    public float Speed = 20f;
    public Transform FollowPos = null;

    private void Update()
    {
        this.transform.LookAt(FollowPos);
        //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(98f, -25f, 120f), Speed * Time.deltaTime);
    }
}
