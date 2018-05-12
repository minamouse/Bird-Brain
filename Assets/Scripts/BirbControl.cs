using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirbControl : MonoBehaviour {

    List<Vector3> allPositions;
    // Use this for initialization
    void Start () {
        allPositions = new List<Vector3>
        {
            new Vector3(511.17f, 36.59f, 386.06f),
            new Vector3(490.178f, 47.37f, 376.5f),
            new Vector3(495.027f, 48.821f, 348.245f)
        };
    }

    public Vector3 GetPosition ()
    {
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
