using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[RequireComponent(typeof(PlayerController))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;
    private PlayerController controller;
    private Animator animator;

    private bool playerActionFrozen;

    void Start()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!playerActionFrozen) {
            Vector2 playerInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector2 velocity = playerInput * speed;

            velocity = Vector2.ClampMagnitude(velocity, speed) * Time.deltaTime;
            ApplyAnimation(velocity);
            controller.Move(velocity);

            if(Input.GetKeyDown(KeyCode.Space)) {
                Interactable interactable = controller.CheckForInteractables();
                if (interactable != null) {
                    playerActionFrozen = interactable.OnInteraction(UnfreezePlayer);

                }
            }
        }
    }

    void ApplyAnimation(Vector2 velocity) {
        int directionX = Math.Sign(velocity.x);
        int directionY = Math.Sign(velocity.y);
        if(animator != null) {
            animator.SetInteger("DirectionX", directionX);
            animator.SetInteger("DirectionY", directionY);
        } else {
            Debug.Log("Player Animator is not set");
        }
    }

    public void UnfreezePlayer() {
        playerActionFrozen = false;
    }

}
