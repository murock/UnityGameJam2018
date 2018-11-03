using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour {

    public Collider2D headCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.otherCollider);
        if (collision.gameObject.tag == "Player" && collision.otherCollider == headCollider)
        {
            PlayerScore.playerScore += 20;
            this.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player" && !collision.otherCollider == headCollider)
        {
            GameManager.Instance.gameOverTxt.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            PlayerScore.playerScore += 5;
            this.gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "endPoint" || collision.gameObject.tag == "Player")
        {
            GameManager.Instance.gameOverTxt.gameObject.SetActive(true);          
        }
    }
}
