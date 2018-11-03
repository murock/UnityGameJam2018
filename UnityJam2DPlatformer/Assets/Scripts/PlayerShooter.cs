using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {

    [SerializeField]
    string projectileName;

    [SerializeField]
    private float fireRate = 0.2f;
    private float fireCooldown;
    private bool allowFire;
    private bool isShooting;

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            isShooting = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            isShooting = false;
        }
        if (isShooting)
        {
            this.Fire();
        }
    }

    private void Fire()
    {
        if (!allowFire && Time.time > fireCooldown)
        {
            allowFire = true;
        }
        if (allowFire)
        {
            allowFire = false;
            Projectile projectileScript = GameManager.Instance.Pool.GetObject(projectileName).GetComponent<Projectile>();
            projectileScript.gameObject.transform.position = transform.position;
            projectileScript.direction = Vector3.right;
            fireCooldown = Time.time + fireRate;
        }


    }
}
