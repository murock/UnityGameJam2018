using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public int playerSpeed = 10;
    public int playerJumpPower = 1250;
    private bool facingRight = true;
    private float moveX;
    public bool isGrounded;

	// Update is called once per frame
	void Update () {
        PlayerMove();
	}
    void PlayerMove()
    {
        // Controls
        this.moveX = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Jump"))
        {
            this.Jump();
        }
        // Animation
        // Player Direction
        if (this.moveX < 0.0f && !this.facingRight)
        {
            FlipPlayer();
        }
        else if (moveX > 0.0f && this.facingRight)
        {
            FlipPlayer();
        }
        // Physics
        this.gameObject.GetComponent<Rigidbody2D>().velocity =
            new Vector2(this.moveX * this.playerSpeed, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);

    }

    void Jump()
    {
        // Jumping Code
        if (this.isGrounded)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * this.playerJumpPower);
            this.isGrounded = false;
        }
    }

    void FlipPlayer()
    {
        this.facingRight = !this.facingRight;
        // Flip the player using the scale
        Vector2 localScale = this.gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("Player has collided with " + col.collider.name);
        if (col.gameObject.tag == "ground")
        {
            this.isGrounded = true;
        }
    }
}
