using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;
    public bool bothDirections = false;

	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(XMoveDirection, -1) * EnemySpeed;
         RaycastHit2D hit = Physics2D.Raycast(this.transform.position, new Vector2(XMoveDirection, 0));
        // When hits another gameobject turn around
        if (bothDirections && hit.distance < 0.6f)
        {
            Flip();
        }
    }

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
