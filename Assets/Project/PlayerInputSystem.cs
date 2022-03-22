using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Cinemachine;

public class PlayerInputSystem : MonoBehaviour
{
    private PlayerInputSystem playerInputSystem;
    private PlayerInputActions playerInputActions;
    private CharacterController characterController;


    private Animator animator;

    


    Vector2 inputMovement;
    Vector3 horizontalMovement;

    private bool inInteractableCollider = false;


    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 360f;
    [SerializeField] float digTime=2f;
    [SerializeField] Transform RotatePlayerPoint;

    

    private void Awake()
    {
        playerInputSystem = GetComponent<PlayerInputSystem>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        Cursor.visible = false;


        playerInputActions = new PlayerInputActions();
        

    }
    private void OnEnable()
    {
        playerInputActions.Player.Enable();
        playerInputActions.Player.Movement.performed += Movement_performed;
        playerInputActions.Player.Interact.performed += Movement_Interact;
    }

    private void Movement_Interact(InputAction.CallbackContext obj)
    {
        if (inInteractableCollider)
        {
            
            StartCoroutine(DigCoroutine());
            
        }
    }

    IEnumerator DigCoroutine()
    {
        Debug.Log("Start Waiting");
        playerInputActions.Player.Movement.Disable();
        animator.SetBool("IsDigging", true);

        yield return new WaitForSeconds(digTime);

        playerInputActions.Player.Movement.Enable();
        animator.SetBool("IsDigging", false);
        Debug.Log("Stoped Waiting");
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
    }
    private void Movement_performed(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }

    

    private void Update()
    {
        
        inputMovement = playerInputActions.Player.Movement.ReadValue<Vector2>();
        horizontalMovement = (transform.right * inputMovement.x + transform.forward * inputMovement.y);
        characterController.Move(horizontalMovement * moveSpeed * Time.deltaTime);

        if (horizontalMovement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(horizontalMovement, Vector3.up);
            RotatePlayerPoint.rotation = Quaternion.RotateTowards(RotatePlayerPoint.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        animator.SetFloat("VelocityZ", inputMovement.y);
        animator.SetFloat("VelocityX", inputMovement.x);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Interactable")) inInteractableCollider = true;
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Interactable")) inInteractableCollider = false;
    }


}
