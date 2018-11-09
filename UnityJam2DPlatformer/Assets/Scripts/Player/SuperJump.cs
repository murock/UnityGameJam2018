using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;

public class SuperJump : MonoBehaviour {

    public const float superJumpCooldown = 5f;
    public const float superJumpDuration = 2f;
    public PlatformerCharacter2D player;
    public float extraJumpPower = 200f;
    public SpriteRenderer highlight;

    private bool isSuperJump = false;
    private float totalSuperJumpCooldown;
    private float totalSuperJumpDuration;

    private void Start()
    {
        highlight.transform.SetParent(player.transform);
    }

    private void Update()
    {
        if (Time.time > totalSuperJumpCooldown && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("fire2 pressed");
            // Increase player jump force
            player.m_JumpForce = player.m_JumpForce + extraJumpPower;
            // Reset Cooldown
            totalSuperJumpCooldown = Time.time + superJumpCooldown;
            // Set Buff duration
            totalSuperJumpDuration = Time.time + superJumpDuration;
            // Set flag
            isSuperJump = true;
            // Set highlight color green
            highlight.color = new Color32(0, 255, 3, 139);
        }
        if (Time.time > totalSuperJumpCooldown)
        {
            // Set highlight color yellow
            highlight.color = new Color32(252, 255, 0, 139);
        }
        if (isSuperJump && Time.time > totalSuperJumpDuration)
        {
            isSuperJump = false;
            player.m_JumpForce = player.m_JumpForce - extraJumpPower;
            // Set highlight color red
            highlight.color = new Color32(255, 10, 0, 139);
        }
    }

}
