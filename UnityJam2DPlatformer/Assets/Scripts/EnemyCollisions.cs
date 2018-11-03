using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour {

    public Collider2D headCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collider is " + collision.otherCollider + "Collision with: " + collision.gameObject.tag);
      //  Debug.Log("Collision with: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Player" && collision.otherCollider == headCollider)
        {
            PlayerScore.playerScore += 20;
            this.gameObject.SetActive(false);
        }
        else if (collision.gameObject.tag == "Player" && !(collision.otherCollider == headCollider))
        {
            Debug.Log("game over " + collision.otherCollider.name);
            GameManager.Instance.GameOver();
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
        else if (collision.gameObject.tag == "endPoint" )
        {
            GameManager.Instance.GameOver();      
        }
    }
}
