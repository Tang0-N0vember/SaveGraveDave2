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
    [SerializeField] Transform rotatePlayerPoint;
    [SerializeField] GameObject invenory;

    public GameObject currentGrave;

    public bool isInvetoryOpen = false;


    

    

    private void Awake()
    {
        playerInputSystem = GetComponent<PlayerInputSystem>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        Cursor.visible = isInvetoryOpen;


        playerInputActions = new PlayerInputActions();
        

    }
    private void OnEnable()
    {
        playerInputActions.Player.Enable();
        playerInputActions.Player.Movement.performed += Movement_performed;
        playerInputActions.Player.Interact.performed += Movement_Interact;
        playerInputActions.Player.Inventory.performed += Inventory_performed;
    }

    private void Inventory_performed(InputAction.CallbackContext context)
    {
        OpenCloseInventory();
    }

    private void Movement_Interact(InputAction.CallbackContext context)
    {
        if (inInteractableCollider)
        {
            StartCoroutine(DigCoroutine());
        }
    }

    IEnumerator DigCoroutine()
    {
        
        if(currentGrave!=null)
        {
            if (!currentGrave.GetComponentInParent<Grave>().IsGraveOpen())
            {
                Debug.Log("Start Diggin");
                playerInputActions.Player.Movement.Disable();
                playerInputActions.Player.Inventory.Disable();
                animator.SetBool("IsDigging", true);

                yield return new WaitForSeconds(digTime);

                playerInputActions.Player.Movement.Enable();
                playerInputActions.Player.Inventory.Enable();
                animator.SetBool("IsDigging", false);
                Debug.Log("Stoped Digging");
                currentGrave.GetComponentInParent<Grave>().OpenGrave();
            }
            else
            {
                Debug.Log("Grave is Already Open");
            }
            
        }
            
    }

    private void OnDisable()
    {
        playerInputActions.Player.Disable();
        playerInputActions.Player.Movement.performed -= Movement_performed;
        playerInputActions.Player.Interact.performed -= Movement_Interact;
        playerInputActions.Player.Inventory.performed -= Inventory_performed;
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
            rotatePlayerPoint.rotation = Quaternion.RotateTowards(rotatePlayerPoint.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    private void FixedUpdate()
    {
        animator.SetFloat("VelocityZ", inputMovement.y);
        animator.SetFloat("VelocityX", inputMovement.x);
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Interactable"))
        {
            currentGrave = collider.gameObject;
            inInteractableCollider = true;
            //collider.GetComponent<Grave>().OpenGrave();
        }
        if (collider.GetComponent<ICollectible>() != null)
        {
            ICollectible collectible = collider.GetComponent<ICollectible>();
            if (collectible != null)
            {
                collectible.Collect();
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Interactable")) 
        {
            currentGrave = null;
            inInteractableCollider = false; 
        }
        
    }

    public void OpenCloseInventory()
    {
        isInvetoryOpen = !isInvetoryOpen;
        invenory.SetActive(isInvetoryOpen);
        Cursor.visible = isInvetoryOpen;
        if (isInvetoryOpen)
        {
            playerInputActions.Player.Movement.Disable();
            playerInputActions.Player.Interact.Disable();
        }
        else
        {
            
            playerInputActions.Player.Movement.Enable();
            playerInputActions.Player.Interact.Enable();
        }
    }
    
}
