using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    private float timeLeft = 120;
    public int playerScore = 0;
    public Text timeLeftTxt;
    public Text playerScoreTxt;

    // Update is called once per frame
    void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftTxt.text = ("Time Left: " + (int)timeLeft);
        playerScoreTxt.text = ("Score: " + playerScore);
        if (timeLeft < 0.1f)
        {
            PlayerHealth.Die();
        }
	}

    private void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.name == "EndLevel")
        {
            this.CountScore();
        }
        else if(trig.gameObject.tag == "present")
        {
            playerScore += 10;
            Destroy(trig.gameObject);
        }
    }

    void CountScore()
    {
        playerScore += (int)timeLeft*10;
        Debug.Log(playerScore.ToString());
    }
}
