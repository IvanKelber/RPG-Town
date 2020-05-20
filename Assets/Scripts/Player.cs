using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour
{


    [SerializeField]
    private UserInput playerInput;

    private PlayerController controller;
    private PlayerInventoryManager inventory;

    private Animator animator;

    [SerializeField]
    private float walkSpeed = 3;

    [SerializeField]
    private float runSpeed = 6;

    public KeyItem mask;

    private bool playerActionFrozen = false;
    private bool inventoryOpen = false;

    public InventoryDisplay inventoryDisplay;
    void Awake()
    {
        inventory = GetComponent<PlayerInventoryManager>();
        if(inventory == null) {
            Debug.LogError("Player Inventory Manager is missing");
        }
        controller = GetComponent<PlayerController>();
        if(controller == null) {
            Debug.LogError("Player controller is missing");
        }

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!playerActionFrozen) {
            Vector2 moveAmount = GetMovement(Time.deltaTime);
            controller.Move(moveAmount);
            ApplyAnimation(moveAmount);
            playerActionFrozen = Interact(); //Checks for and interacts with interactables

            

           
        }

        if(playerInput.InventoryKey()) {
            inventoryOpen = !inventoryOpen;
            inventoryDisplay.transform.gameObject.SetActive(inventoryOpen);
        }
    }

    private bool Interact() {
        if(playerInput.ActionKey()) {
            Interactable interactable = controller.CheckForInteractables();
            if (interactable != null) {
                return interactable.OnInteraction();
            }
        }
        return false;
    }

    private Vector2 GetMovement(float delta) {
        float speed = playerInput.RunKey() ? runSpeed : walkSpeed;
        return Vector2.ClampMagnitude(playerInput.DirectionalInput() * speed, speed) * delta;
    }

    void ApplyAnimation(Vector2 velocity) {
        int directionX = Math.Sign(velocity.x);
        int directionY = Math.Sign(velocity.y);
        if(animator != null) {
            animator.SetInteger("DirectionX", directionX);
            animator.SetInteger("DirectionY", directionY);
        } else {
            Debug.LogWarning("Player Animator is not set");
        }
    }

    public void FreezePlayer(bool freeze) {
        playerActionFrozen = freeze;
    }
}