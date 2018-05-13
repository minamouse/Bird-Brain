using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Results : MonoBehaviour {

    // Use this for initialization
    public GameObject lose;
    public GameObject won;

    void Start () {
		if (GameStats.Won())
        {
            lose.SetActive(false);
            won.SetActive(true);
        } else
        {
            lose.SetActive(true);
            won.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
        {
            if (GameStats.Next())
            {
                SceneManager.LoadScene("CueScene");
            } else
            {
                SceneManager.LoadScene("EndScene");
            }
        }
    }
}
