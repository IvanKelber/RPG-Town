using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public PlayerController target;

    public BoxCollider2D outerBounds;

    public Vector2 focusAreaSize;
    public FocusArea focusArea;
    public float lookAheadDstX;
    public float lookAheadSmoothTimeX;
    public float lookAheadDstY;
    public float lookAheadSmoothTimeY;


    float currentLookAheadX;
    float targetLookAheadX;  

    float lookAheadDirX;

    float currentLookAheadY;
    float targetLookAheadY;
     
    float lookAheadDirY;
    float smoothLookVelocityX;
    float smoothVelocityY;


    bool lookAheadStoppedX;
    bool lookAheadStoppedY;

    float cameraWidth;
    float cameraHeight;
    private void Start()
    {
        focusArea = new FocusArea(target.collider.bounds, focusAreaSize);
        Camera cam = GetComponent<Camera>();
        cameraHeight = 2f * cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;
    }

    private void LateUpdate()
    {
        focusArea.Update(target.collider.bounds);
        Vector2 focusPosition = focusArea.center;

        if (focusArea.velocity.x != 0)
        {
            lookAheadDirX = Mathf.Sign(focusArea.velocity.x);
            if (Mathf.Sign(target.facingDirection.x) == Mathf.Sign(focusArea.velocity.x) && target.facingDirection.x != 0)
            {
                lookAheadStoppedX = false;
                targetLookAheadX = lookAheadDirX * lookAheadDstX;
            }
            else if (!lookAheadStoppedX)
            {
                lookAheadStoppedX = true;
                targetLookAheadX = currentLookAheadX + (lookAheadDirX * lookAheadDstX - currentLookAheadX) / 4f;
            }
        }

        if (focusArea.velocity.y != 0)
        {
            lookAheadDirY = Mathf.Sign(focusArea.velocity.y);
            if (Mathf.Sign(target.facingDirection.y) == Mathf.Sign(focusArea.velocity.y) && target.facingDirection.y != 0)
            {
                lookAheadStoppedY = false;
                targetLookAheadY = lookAheadDirY * lookAheadDstY;
            }
            else if (!lookAheadStoppedY)
            {
                lookAheadStoppedY = true;
                targetLookAheadY = currentLookAheadY + (lookAheadDirY * lookAheadDstY - currentLookAheadY) / 4f;
            }
        }

        currentLookAheadX = Mathf.SmoothDamp(currentLookAheadX, targetLookAheadX, ref smoothLookVelocityX, lookAheadSmoothTimeX);
        currentLookAheadY = Mathf.SmoothDamp(currentLookAheadY, targetLookAheadY, ref smoothVelocityY, lookAheadSmoothTimeY);


        focusPosition += new Vector2(currentLookAheadX, currentLookAheadY);


        
        float minX = outerBounds.bounds.min.x + cameraWidth/2;
        float maxX = outerBounds.bounds.max.x - cameraWidth/2;
        float minY = outerBounds.bounds.min.y + cameraHeight/2;
        float maxY = outerBounds.bounds.max.y - cameraHeight/2;

        focusPosition.x = Mathf.Clamp(focusPosition.x, minX, maxX);
        focusPosition.y = Mathf.Clamp(focusPosition.y, minY, maxY);
        Debug.Log("focusPosition: " + focusPosition);
        transform.position = (Vector3)focusPosition + Vector3.forward * -10;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 1, .5f);
        Gizmos.DrawCube(focusArea.center, focusAreaSize);
    }

    public struct FocusArea
    {
        public Vector2 center;
        public Vector2 velocity;
        float left, right;
        float top, bottom;

        public FocusArea(Bounds targetBounds, Vector2 size)
        {
            left = targetBounds.center.x - size.x / 2;
            right = left + size.x;
            bottom = targetBounds.min.y;
            top = bottom + size.y;

            center = new Vector2((left + right) / 2, (top + bottom) / 2);
            velocity = Vector2.zero;
        }

        public void Update(Bounds targetBounds)
        {
            float shiftX = 0;
            if (targetBounds.min.x < left)
            {
                shiftX = targetBounds.min.x - left;
            }
            else if (targetBounds.max.x > right)
            {
                shiftX = targetBounds.max.x - right;
            }
            left += shiftX;
            right += shiftX;

            float shiftY = 0;
            if (targetBounds.min.y < bottom)
            {
                shiftY = targetBounds.min.y - bottom;
            }
            else if (targetBounds.max.y > top)
            {
                shiftY = targetBounds.max.y - top;
            }
            bottom += shiftY;
            top += shiftY;

            center = CalculateCenter();
            velocity = new Vector2(shiftX, shiftY);
        }

        private Vector2 CalculateCenter()
        {
            return new Vector2((left + right) / 2, (top + bottom) / 2);
        }
    }


}
