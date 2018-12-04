using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
    //old properties
    public int EnemySpeed = 2;
    public int XMoveDirection = -1;
    public bool bothDirections = false;

    [Header("Obstacle Detection")]
    /// If set to true, the agent will change direction when hitting a wall
    public bool ChangeDirectionOnWall = true;
    /// If set to true, the agent will try and avoid falling
    public bool AvoidFalling = true;
    /// The offset the hole detection should take into account
    public Vector3 HoleDetectionOffset = new Vector3(0, 0, 0);
    /// the length of the ray cast to detect holes
    public float HoleDetectionRaycastLength = 1f;


    private void Start()
    {

    }

    private void Update()
    {
        
    }

    private void HandleMovement()
    {

        // If the value of the horizontal axis is positive, the character must face right.
        if (_horizontalMovement > 0.1f)
        {
            _normalizedHorizontalSpeed = _horizontalMovement;
            if (!_character.IsFacingRight)
                _character.Flip();
        }
        // If it's negative, then we're facing left
        else if (_horizontalMovement < -0.1f)
        {
            _normalizedHorizontalSpeed = _horizontalMovement;
            if (_character.IsFacingRight)
                _character.Flip();
        }
        else
        {
            _normalizedHorizontalSpeed = 0;
        }
    }

    //// Update is called once per frame
    //void Update () {
    //       this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, -1) * EnemySpeed;
    //        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, new Vector2(XMoveDirection, 0));
    //       // When hits another gameobject turn around
    //       if (bothDirections && hit.distance < 0.6f)
    //       {
    //           Flip();
    //       }
    //   }

    public void Flip()
    {
        if (XMoveDirection > 0)
        {
            XMoveDirection = -1;
        }
        else
        {
            XMoveDirection = 1;
        }
    }
}
