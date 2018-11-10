using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.position.y < - 10)
        {
            ResetScene();
        }
	}

    public static void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Spawner.spawnerOn = true;
    }
}
