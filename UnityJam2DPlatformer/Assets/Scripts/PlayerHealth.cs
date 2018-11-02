using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (this.gameObject.transform.position.y < - 10)
        {
            Die();
        }
	}

    public static void Die()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
