using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cue : MonoBehaviour {

    public AudioClip bluejay;
    public AudioClip cardinal;
    public AudioClip sparrow;
    public AudioClip chickadee;
    public AudioClip crow;
    public AudioClip goldfinch;
    public AudioClip robin;
    public AudioSource myAudio;
    private Dictionary<string, AudioClip> birdSongs;

    // Use this for initialization
    void Start () {
        myAudio = GetComponent<AudioSource>();
        
        birdSongs = new Dictionary<string, AudioClip>() {
            { "bluejay", bluejay },
            { "cardinal", cardinal },
            { "sparrow", sparrow },
            { "chickadee", chickadee },
            { "crow", crow },
            { "goldfinch", goldfinch },
            { "robin", robin }
        };
        string currentBird = GameStats.NextBird();
        myAudio.PlayOneShot(birdSongs[currentBird]);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("space"))
            SceneManager.LoadScene("ForestScene");

    }
}
