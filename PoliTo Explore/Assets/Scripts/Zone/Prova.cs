using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prova : MonoBehaviour
{
    public float Speed = 20f;
    public Transform[] FollowPos;
    private Transform tra;

    private void Update()
    {
        this.transform.LookAt(tra);
        //this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, Quaternion.Euler(98f, -25f, 120f), Speed * Time.deltaTime);
    }

    public Transform SetFollow(GameObject gO)
    {
        for(int i=0; i<FollowPos.Length; i++) {
            if (gO.transform == FollowPos[i])
            {
                tra = FollowPos[i];
            }
        }
        return tra;
    }
}
