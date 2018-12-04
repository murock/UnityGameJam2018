using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class Stompable : MonoBehaviour {

    /// The force the hit will apply to the stomper
    public Vector2 KnockbackForce = new Vector2(0f, 15f);
    /// the length of the rays
    public float RaycastLength = 0.5f;
    // the number of rays
    public int NumberOfRays = 5;
    // the layer the player is on
    public LayerMask PlayerMask;

    private BoxCollider2D boxCollider;
    private Vector2 verticalRayCastStart;
    private Vector2 verticalRayCastEnd;
    private RaycastHit2D[] hitsStorage;

    // My additions
    private bool isDead;

    // Use this for initialization
    void Start () {
        boxCollider = GetComponent<BoxCollider2D>();
        hitsStorage = new RaycastHit2D[NumberOfRays];
        isDead = false;
    }
	
	// Update is called once per frame
	void Update () {
        CastRaysAbove();
	}

    private void CastRaysAbove()
    {
        bool hitConnected = false;
        int hitConnectedIndex = 0;

        verticalRayCastStart.x = boxCollider.bounds.min.x;
        verticalRayCastStart.y = boxCollider.bounds.max.y;
        verticalRayCastEnd.x = boxCollider.bounds.max.x;
        verticalRayCastEnd.y = boxCollider.bounds.max.y;

        for (int i = 0; i < NumberOfRays; i++)
        {
            Vector2 rayOriginPoint = Vector2.Lerp(verticalRayCastStart, verticalRayCastEnd, (float)i / (float)(NumberOfRays - 1));
            hitsStorage[i] = RayCast(rayOriginPoint, Vector2.up, RaycastLength, PlayerMask, Color.gray, true);

            // RaycastHit is true when hits player
            if (hitsStorage[i])
            {
                hitConnected = true;
                hitConnectedIndex = i;
                break;
            }
        }

        

        if (hitConnected)
        {
            // Do nothing if player is below enemie i.e enemie not hit from above
            if (boxCollider.bounds.max.y > hitsStorage[hitConnectedIndex].collider.bounds.min.y)
            {
                return;
            }

            PlatformerCharacter2D playerController = hitsStorage[hitConnectedIndex].collider.gameObject.GetComponent<PlatformerCharacter2D>();
            if (playerController != null)
            {
                PerformStomp(playerController);
            }

        }
    }

    private void PerformStomp(PlatformerCharacter2D playerController)
    {
        // Increment player score and kill enemy
        PlayerScore.playerScore += 20;
        GameManager.Instance.Pool.ReleaseObject(this.gameObject);

        playerController.SetForce(KnockbackForce);
    }

    /// <summary>
    /// Draws a debug ray in 2D and does the actual raycast
    /// </summary>
    /// <returns>The raycast hit.</returns>
    /// <param name="rayOriginPoint">Ray origin point.</param>
    /// <param name="rayDirection">Ray direction.</param>
    /// <param name="rayDistance">Ray distance.</param>
    /// <param name="mask">Mask will only collide with this layer.</param>
    /// <param name="debug">If set to <c>true</c> debug.</param>
    /// <param name="color">Color.</param>
    public static RaycastHit2D RayCast(Vector2 rayOriginPoint, Vector2 rayDirection, float rayDistance, LayerMask mask, Color color, bool drawGizmo = false)
    {
        if (drawGizmo)
        {
            Debug.DrawRay(rayOriginPoint, rayDirection * rayDistance, color);
        }
        return Physics2D.Raycast(rayOriginPoint, rayDirection, rayDistance, mask);
    }
}
