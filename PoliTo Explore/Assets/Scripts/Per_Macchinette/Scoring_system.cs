using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoring_system : MonoBehaviour
    {
    public GameObject scoreText;
    public static int theScore;

    private void Update()
    {
        scoreText.GetComponent < Text> ().text = "Aree macchinette trovate: " + theScore + "/4";
    }
}
