using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour {

    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    // Use this for initialization
    void Start () {
        this.player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame at the end of update cycle
	void LateUpdate () {
        float x = Mathf.Clamp(this.player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(this.player.transform.position.y, yMin, yMax);
        this.gameObject.transform.position = new Vector3(x, y, gameObject.transform.position.z);
    }


}
