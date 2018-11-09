using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

    public ObjectPool Pool { get; set; }
    public bool isGameOver = false;
    public GameObject pauseMenu;

    [SerializeField]
    private Text gameOverTxt;
    [SerializeField]
    private GameObject player;


	// Use this for initialization
	void Start () {
		
	}


    private void Update()
    {
        HandlePause();
    }

    private void Awake()    //called after all components have intialized called before start
    {
        Pool = GetComponent<ObjectPool>();
    }


    public void GameOver()
    {
        isGameOver = true;
        gameOverTxt.gameObject.SetActive(true);
        Animator playerAnimator = player.GetComponent<Animator>();
        playerAnimator.SetTrigger("Die");
    }

    public void GameWon()
    {
        if (!isGameOver)
        {
            gameOverTxt.text = "You Saved" + Environment.NewLine + "Christmas!";
            gameOverTxt.gameObject.SetActive(true);
        }
    }

    private void HandlePause()
    {
        if (Input.GetButtonDown("Pause"))
        {
            if (Time.timeScale == 1)
            {
                // Pause time
                Time.timeScale = 0;
                if (pauseMenu != null)
                {
                    pauseMenu.SetActive(true);
                }
            }
            else
            {
                // Resume
                Time.timeScale = 1;
                if (pauseMenu != null)
                {
                    pauseMenu.SetActive(false);
                }
            }
        }
    }

}
