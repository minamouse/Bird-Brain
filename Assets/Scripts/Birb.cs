using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birb : MonoBehaviour {

    Vector3 startPos;
    Vector3 goalPos;
    int time;
    int currentTime;
    bool isMoving;
    Animator animations;
    public BirbControl birbControl;

	// Use this for initialization
	void Start () {
       // birbControl = GetComponent<BirbControl>();
        animations = GetComponent<Animator>();
        Debug.Log(birbControl);
        startPos = birbControl.GetPosition();
        transform.position = startPos;
        time = 210;
        currentTime = 0;
        isMoving = false;
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
        
		
	}
}
