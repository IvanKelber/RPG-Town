using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerController : RaycastController
{

    public Vector2 facingDirection = Vector2.down;

    [SerializeField]
    private LayerMask interactableMask;
    public void Move(Vector2 moveAmount)
    {
        UpdateRaycastOrigins();
        if(moveAmount.x != 0) {
            HorizontalCollisions(ref moveAmount);
        }
        if(moveAmount.y != 0) {
            VerticalCollisions(ref moveAmount);
        }
        transform.Translate(moveAmount);
        float directionX = Math.Sign(moveAmount.x);
        float directionY = Math.Sign(moveAmount.y);

        if(directionX != 0 ) {
            facingDirection = Vector2.right * directionX;
        } else if (directionY != 0 ) {
            facingDirection = Vector2.up * directionY;
        } 
        Color rayColor = Color.red;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facingDirection, 1, interactableMask);

        if(hit) {
            rayColor = Color.green;
        }
        Debug.DrawRay(transform.position, facingDirection * 1, rayColor);

    }

     void HorizontalCollisions(ref Vector2 moveAmount)
    {
        float directionX = Mathf.Sign(moveAmount.x);
        float rayLength = Mathf.Abs(moveAmount.x) + skinWidth;

        if (Mathf.Abs(moveAmount.x) < skinWidth)
        {
            rayLength = 2 * skinWidth;
        }

        for (int i = 0; i < horizontalRayCount; i++)
        {
            Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
            rayOrigin += Vector2.up * (horizontalRaySpacing * i);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * directionX, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.right * directionX * rayLength, Color.red);

            if (hit)
            {
                moveAmount.x = (hit.distance - skinWidth) * directionX;
                rayLength = hit.distance;
            }
        }
    }

    void VerticalCollisions(ref Vector2 moveAmount)
    {
        float directionY = Mathf.Sign(moveAmount.y);
        float rayLength = Mathf.Abs(moveAmount.y) + skinWidth;

        for (int i = 0; i < verticalRayCount; i++)
        {
            Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
            rayOrigin += Vector2.right * (verticalRaySpacing * i + moveAmount.x);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLength, collisionMask);

            Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLength, Color.red);

            if (hit)
            {
                moveAmount.y = (hit.distance - skinWidth) * directionY;
                rayLength = hit.distance;
               
            }
        }
    }

    public Interactable CheckForInteractables() {
        Debug.Log("Checking for interactables");
        RaycastHit2D hit = Physics2D.Raycast(transform.position, facingDirection, 1, interactableMask);

        if(hit) {
            return hit.transform.gameObject.GetComponent<Interactable>();
        }
        Debug.Log("Nothing found");
        return null;
    }
}
