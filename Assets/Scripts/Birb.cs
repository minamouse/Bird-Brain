using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Birb : MonoBehaviour {

    Vector3 startPos;
    Vector3 goalPos;
    int time;
    int currentTime;
    bool isMoving;
    Animator animations;
    public BirbControl birbControl;
    public Camera cam;
    AudioSource song;

	// Use this for initialization
	void Start () {
       // birbControl = GetComponent<BirbControl>();
        animations = GetComponent<Animator>();
        startPos = birbControl.GetPosition();
        transform.position = startPos;
        time = 210;
        currentTime = 0;
        isMoving = false;
        song = GetComponent<AudioSource>();
        if (name == GameStats.NextBird())
        {
            song.volume = 1;
        } else
        {
            song.volume = 0.5f;
        }

    }

    // Update is called once per frame
    void Update() {

        if (isMoving)
        {
            if (transform.position == goalPos) {
                currentTime = 0;
                isMoving = false;
                animations.SetTrigger("stopFlying");
                birbControl.ReturnPosition(startPos);
                startPos = goalPos;
            } else
            {
                transform.position = Vector3.MoveTowards(transform.position, goalPos, Time.deltaTime * 10);
            }
        } else
        {
            currentTime += 1;
            if (currentTime == time)
            {
                isMoving = true;
                goalPos = birbControl.GetPosition();
                transform.LookAt(goalPos);
                animations.SetTrigger("startFlying");
            }

        }

        if (Input.GetKeyDown("space"))
        {
            //calculate if the correct bird was in the frame
            if (name == GameStats.NextBird())
            {
                Vector3 relativePos = cam.WorldToViewportPoint(transform.position);
                if (relativePos.x >= 0 && relativePos.x <= 1 && relativePos.y >= 0 && relativePos.y <= 1 && relativePos.z >= 0)
                {
                    GameStats.SetFound(name);
                }
            }
            SceneManager.LoadScene("FoundBird");

        }


    }
}
