using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using ScriptableObjectArchitecture;
using UnityEngine.SceneManagement;
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
    [SerializeField]
    private GameEvent toggleEquipmentEvent;
    private bool playerActionFrozen = false;

    private Animator animator;

    public BaseItem mask;
    public BaseItem mask2;

    public SceneInfo playerScene;
    void Awake()
    {
        LoadSceneState();
        controller = GetComponent<PlayerController>();
        if(controller == null) {
            Debug.LogError("Player controller is missing");
        }

        animator = GetComponent<Animator>();
    }

    void OnDestroy() {
        SaveSceneState();
    }

    void LoadSceneState() {
        this.transform.position = playerScene.GetPlayerPosition();
    }

    void SaveSceneState() {
        playerScene.SetPlayerPosition(this.transform.position);
    }

    void Update()
    {
        controller.CheckForForeground();
        if(!playerActionFrozen) {
            Vector2 moveAmount = GetMovement(Time.deltaTime);
            controller.Move(moveAmount);
            ApplyAnimation(moveAmount);
            Interact(); //Checks for and interacts with interactables    
        }

        if(playerInput.InventoryKey()) {
            toggleInventoryEvent.Raise();
        }

        if(playerInput.EquipmentKey()) {
            toggleEquipmentEvent.Raise();
        }


        //Test code
        if(Input.GetKeyDown(KeyCode.T)) {
            inventory.Add(mask);
        }

        if(Input.GetKeyDown(KeyCode.R)) {
            inventory.Add(mask2);
        }

        if(Input.GetKeyDown(KeyCode.U)) {
            SceneManager.LoadScene(2);
        }
        // end test code

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