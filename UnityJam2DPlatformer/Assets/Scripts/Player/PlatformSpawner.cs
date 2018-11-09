using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformSpawner : Singleton<PlatformSpawner> {

    public float intialCoolDown = 10f;
    public const float coolDown = 5f;
    private bool isReady = false;
    public Image powerUpImage;


    private float totalCoolDown;

    private List<Vector3> platformPositions;

    public bool IsReady {
        set
        {
            isReady = value;
            if (value)
            {
                powerUpImage.color = new Color32(255, 255, 255, 255);    
            }
            else
            {
                powerUpImage.color = new Color32(255, 0, 0, 255);
            }

        }
    }

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
        if (Input.GetButtonDown("Fire3") && isReady && Time.timeSinceLevelLoad > intialCoolDown)
        {
            IsReady = false;
            Debug.Log("Fire 3 pressed");
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).position = platformPositions[i];
            }
        }
	}
}
