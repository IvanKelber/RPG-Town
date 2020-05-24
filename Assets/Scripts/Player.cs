using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using ScriptableObjectArchitecture;

public class Player : MonoBehaviour
{


    [SerializeField]
    private UserInput playerInput;

    private PlayerController controller;

    [SerializeField]
    private ItemCollection inventory;

    public DerivedStats stats;


    [SerializeField]
    private float walkSpeed = 3;
    [SerializeField]
    private float runSpeed = 6;

    [SerializeField]
    private GameEvent toggleInventoryEvent;

    private bool playerActionFrozen = false;

    private Animator animator;

    public BaseItem mask;
    public BaseItem mask2;
    void Awake()
    {
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
            Interact(); //Checks for and interacts with interactables    
        }

        if(playerInput.InventoryKey()) {
            toggleInventoryEvent.Raise();
        }

        if(Input.GetKeyDown(KeyCode.T)) {
            inventory.Add(mask);
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            inventory.Add(mask2);
        }

        if(Input.GetKeyDown(KeyCode.G)) {
            Debug.Log("Player Strength = " + stats.Strength);
            Debug.Log("Player Agility = " + stats.Agility);
            Debug.Log("Player Wisdom = " + stats.Wisdom);
            Debug.Log("Player Constitution = " + stats.Constitution);
            Debug.Log("Player Defense = " + stats.Defense);
            Debug.Log("Player Luck = " + stats.Luck);
        }
    }

    private void Interact() {
        if(playerInput.ActionKey()) {
            Interactable interactable = controller.CheckForInteractables();
            if (interactable != null) {
                Debug.Log("Calling interactable");
                interactable.OnInteraction();
            }
        }
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

    public void OnFreezePlayer(bool freeze) {
        Debug.Log("OnFreezePlayer : " + freeze);
        if(freeze) {
            playerActionFrozen = freeze;

        } else {
            StopAllCoroutines();
            StartCoroutine(UnfreezePlayer());
        }
    }

    //Without this single frame delay it's possible to become unfrozen and refrozen in a single frame...
    //TODO: Fix the need for this coroutine
    IEnumerator UnfreezePlayer() {
        yield return null;
        playerActionFrozen = false;
    }
}