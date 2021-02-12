using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ExplorationDataScriptableObject", order = 1)]
public class ExplorationDataScriptableObject : ScriptableObject
{
    public List<GameObject> Discovered;
    public List<GameObject> Discovered1;
    public List<GameObject> Discovered2;
    public List<GameObject> Discovered3;
    public List<GameObject> Discovered4;

    public static int Ntot, N1, N2, N3, N4;

    public void OnEnable()
    {
        Discovered.Clear();
        //Discovered1.Clear();
        //Discovered2.Clear();
        //Discovered3.Clear();
    }

    ///ritorna vero se ha aggiunto, falso se c'era gia
    public bool AddDiscovered(GameObject obj) 
    {
        bool giaScoperto = Discovered.Contains(obj);
        if (!giaScoperto)
        {
            Discovered.Add(obj);
            Debug.Log("Aggiunto oggetto");
        }
        else{
            Debug.Log("Oggetto gia' presente");
        }
        return !(giaScoperto);
    }

   
}