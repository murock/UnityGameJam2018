using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPresentPickUp : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D trig)
    {
        Debug.Log("collsion with: " + trig);
        if (trig.gameObject.tag == "Player")
        {
            Debug.Log("In here");
            PlatformSpawner.Instance.IsReady = true;
            GameManager.Instance.Pool.ReleaseObject(this.gameObject);
        }
    }
}
