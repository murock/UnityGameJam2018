using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour {

    public float timeLeft = 30;
    public static int playerScore = 0;
    public Text timeLeftTxt;
    public Text playerScoreTxt;
    public Transform fallingScorer;

    // Update is called once per frame
    void Update () {
        if (timeLeft > 0.1f)
        {
            timeLeft -= Time.deltaTime;
            timeLeftTxt.text = ("Time Left: " + (int)timeLeft);
            playerScoreTxt.text = ("Score: " + playerScore);
        }
        if (timeLeft < 0.1f)
        {
            GameManager.Instance.GameWon();
        }

        // Climbing level scoring
        if (fallingScorer != null)
        {
            playerScore = (int)this.transform.position.y - (int)fallingScorer.position.y;
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
