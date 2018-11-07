using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public string sceneName;

	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.position.y < - 10)
        {
            ResetScene();
        }
	}

    public void ResetScene()
    {
        if (!String.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
            Spawner.spawnerOn = true;
        }
    }
}
