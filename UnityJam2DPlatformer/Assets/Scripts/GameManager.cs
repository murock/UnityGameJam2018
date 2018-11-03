using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

    [SerializeField]
    private Text gameOverTxt;
    [SerializeField]
    private GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
    public void GameOver()
    {
        gameOverTxt.gameObject.SetActive(true);
        Animator playerAnimator = player.GetComponent<Animator>();
        playerAnimator.SetTrigger("Die");
    }

}
