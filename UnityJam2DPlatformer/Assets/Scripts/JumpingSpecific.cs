using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpingSpecific : MonoBehaviour {

    private bool allowSuperJump = true;
    private float superJumpCooldown = 3f;
    public Text superJumpTxt;
   // public PlatformerChara

    private void Update()
    {
        if (!allowSuperJump && Time.time > superJumpCooldown)
        {
            allowSuperJump = true;
        }
        if (allowSuperJump)
        {
            allowSuperJump = false;
            superJumpCooldown = Time.time + superJumpCooldown;
        }
    }

}
