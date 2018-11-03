using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> {

    public ObjectPool Pool { get; set; }

    [SerializeField]
    private Text gameOverTxt;
    [SerializeField]
    private GameObject player;

	// Use this for initialization
	void Start () {
		
	}

    private void Awake()    //called after all components have intialized called before start
    {
        Pool = GetComponent<ObjectPool>();
    }


    public void GameOver()
    {
        gameOverTxt.gameObject.SetActive(true);
        Animator playerAnimator = player.GetComponent<Animator>();
        playerAnimator.SetTrigger("Die");
    }

}
