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
    public AudioClip song;
    public AudioSource myAudio;
    public int waitTime;
    public int currentWaitTime;

    // Use this for initialization
    void Start () {
        waitTime = Random.Range(1, 4) * 30;
       // birbControl = GetComponent<BirbControl>();
        animations = GetComponent<Animator>();
        startPos = birbControl.GetPosition();
        transform.position = startPos;
        time = 210;
        currentTime = 0;
        isMoving = false;
        myAudio = GetComponent<AudioSource>();
        if (name == GameStats.NextBird())
        {
            myAudio.volume = 1;
        } else
        {
            myAudio.volume = 0.3f;
        }
    }

    // Update is called once per frame
    void Update() {

        currentWaitTime += 1;
        if (currentWaitTime == waitTime)
        {
            waitTime = Random.Range(1, 4) * 30;
            myAudio.PlayOneShot(song);
            currentWaitTime = 0;
        }
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
                time = Random.Range(3, 10) * 30;
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
