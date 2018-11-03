using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {


    [SerializeField]
    GameObject projectile;

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            this.Fire();
        }
    }

    private void Fire()
    {
        GameObject cannonBallGameObject = Instantiate(projectile, transform.position, this.transform.rotation);
        Projectile projectileScript = cannonBallGameObject.GetComponent<Projectile>();
        projectileScript.direction = Vector3.right;
    }
}
