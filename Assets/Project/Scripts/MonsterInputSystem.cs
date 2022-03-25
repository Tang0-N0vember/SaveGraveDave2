using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Cinemachine;

public class MonsterInputSystem : MonoBehaviour
{
    private MonsterInputSystem monsterInputSystem;
    private PlayerInputActions playerInputActions;
    private CharacterController characterController;

    private Animator animator;

    Vector2 inputMovement;
    Vector3 horizontalMovement;

    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 360f;
    [SerializeField] Transform rotatePlayerPoint;

    public GameObject currentGrave;

    public bool isInvetoryOpen = false;

    

    private void Awake()
    {
        monsterInputSystem = GetComponent<MonsterInputSystem>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        Cursor.visible = isInvetoryOpen;


        playerInputActions = new PlayerInputActions();
        

    }
    private void OnEnable()
    {
        playerInputActions.Monster.Enable();
        playerInputActions.Monster.Movement.performed += Movement_performed;
        playerInputActions.Monster.Attack.performed += Attack_performed;

    }
    private void OnDisable()
    {
        playerInputActions.Player.Disable();
        playerInputActions.Player.Movement.performed -= Movement_performed;
        playerInputActions.Player.Movement.performed -= Attack_performed;
    }

    private void Attack_performed(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Attack");
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }

    
    private void Update()
    {
        
        inputMovement = playerInputActions.Monster.Movement.ReadValue<Vector2>();
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
        if (collider.CompareTag("Villager"))
        {
            Debug.Log("Villager");
        }
    }

}
