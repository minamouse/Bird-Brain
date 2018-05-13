using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour {

    // Use this for initialization
    
    void Start() {
        TextMesh text = GetComponent<TextMesh>();
        int score = 0;
        Dictionary<string, bool> results = GameStats.GetResults();
        foreach(bool entry in results.Values)
        {
            if (entry)
            {
                score += 1;
            }
        }
        text.text = "Points: " + score + "/7";
    }
}
