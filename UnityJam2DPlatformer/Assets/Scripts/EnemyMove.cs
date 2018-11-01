﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;

	
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, new Vector2(XMoveDirection, 0));
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, 0) * EnemySpeed;
        // When hits another gameobject turn around
        if (hit.distance < 0.7f)
        {
            Flip();
        }
	}

    void Flip()
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
