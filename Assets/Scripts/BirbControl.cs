using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbControl : MonoBehaviour {

    List<Vector3> allPositions;
    bool initialized = false;
    // Use this for initialization
    void Start () {
        if (initialized)
        {
            return;
        }
        allPositions = new List<Vector3>
        {
            new Vector3(511.17f, 36.59f, 386.06f),
            new Vector3(490.178f, 47.37f, 376.5f),
            new Vector3(495.027f, 48.821f, 348.245f),
            new Vector3(500.462f, 48.291f, 387.105f),
            new Vector3(490.428f, 47.103f, 377.177f),
            new Vector3(500.363f, 46.524f, 386.175f),
            new Vector3(494.735f, 48.568f, 347.068f),
            new Vector3(504.43f, 45.56f, 346.53f),
            new Vector3(487.187f, 40.005f, 369.364f),
            new Vector3(488.738f, 45.025f, 370.318f),
            new Vector3(506.481f, 38.9f, 384.94f),
            new Vector3(520.75f, 48.2f, 378.92f)
        };
        initialized = true;
    }

    public Vector3 GetPosition ()
    {
        if (!initialized)
        {
            Start();
        }
        int ind = Random.Range(0,allPositions.Count-1);
        Vector3 toReturn = allPositions[ind];
        allPositions.RemoveAt(ind);
        return toReturn;
    }

    public void ReturnPosition (Vector3 usedPos)
    {
        allPositions.Add(usedPos);
    }
}
