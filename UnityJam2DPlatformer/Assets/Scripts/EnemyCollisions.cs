using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : LimitedLife
{

    public Collider2D headCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
        if (collision.gameObject.tag != "enemy")
        {
            this.GetComponent<EnemyMove>().Flip();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "projectile")
        {
            PlayerScore.playerScore += 5;
            GameManager.Instance.Pool.ReleaseObject(collision.gameObject);
            GameManager.Instance.Pool.ReleaseObject(this.gameObject);
        }
        else if (collision.gameObject.tag == "endPoint" )
        {
            GameManager.Instance.GameOver();      
        }
    }

}
