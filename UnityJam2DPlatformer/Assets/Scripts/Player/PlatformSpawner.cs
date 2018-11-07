using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    private List<Vector3> platformPositions;

	// Use this for initialization
	void Start () {
        platformPositions = new List<Vector3>();
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            Vector3 platformPosition = this.gameObject.transform.GetChild(i).position;
            platformPositions.Add(platformPosition);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire3"))
        {
            Debug.Log("Fire 3 pressed");
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).position = platformPositions[i];
            }
        }
	}
}
