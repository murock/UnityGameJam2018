using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        Debug.Log("Scenecount is " + SceneManager.sceneCount);
        gameOverTxt.gameObject.SetActive(true);
        gameOverTxt.text = "Press Pause" + Environment.NewLine + "To Start";
        Time.timeScale = 0;
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
        PlayerHealth.ResetScene();
        gameOverTxt.text = "Game Over";
        isGameOver = true;
        gameOverTxt.gameObject.SetActive(true);
        Animator playerAnimator = player.GetComponent<Animator>();
        playerAnimator.SetTrigger("Die");
    }

    public void GameWon()
    {
        if (PersistantInfo.Instance != null)
        {
            PersistantInfo.Instance.sceneNumber++;
            if (SceneManager.sceneCountInBuildSettings > PersistantInfo.Instance.sceneNumber)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }

            if (!isGameOver && PersistantInfo.Instance.sceneNumber > SceneManager.sceneCountInBuildSettings)
            {
                gameOverTxt.text = "You Saved" + Environment.NewLine + "Christmas!";
                gameOverTxt.gameObject.SetActive(true);
                // stop spawning of objects
                Spawner.spawnerOn = false;
                Time.timeScale = 0;
            }
        }
    }

    private void HandlePause()
    {
        if (Input.GetButtonDown("Pause"))
        {
            gameOverTxt.gameObject.SetActive(false);
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
