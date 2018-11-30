using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : LimitedLife
{

    [SerializeField]
    private float speed = 10;

    [SerializeField]
    internal Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("outside: "+collision.gameObject.tag);
        if (collision.gameObject.tag != "enemy" && collision.gameObject.tag != "Player")
        {
            Debug.Log(collision.gameObject.tag);
            GameManager.Instance.Pool.ReleaseObject(this.gameObject);
        }
    }
}
