using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisions : MonoBehaviour {

    public Collider2D headCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.otherCollider == headCollider)
        {
            PlayerScore.playerScore += 20;
            this.gameObject.SetActive(false);
        }
    }
}
