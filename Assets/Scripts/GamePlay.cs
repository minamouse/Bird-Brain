using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour {

    public GameObject cameraLense;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.LeftShift)) {
            cameraLense.SetActive(true);
        }
        else
        {
            cameraLense.SetActive(false);
        }
	}
}
