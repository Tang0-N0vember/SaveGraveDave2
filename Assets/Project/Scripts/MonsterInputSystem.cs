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
    [SerializeField] float sprintSpeed = 10f;
    private float currenSpeed;
    [SerializeField] float rotationSpeed = 360f;
    [SerializeField] float sprintTime=2f;
    [SerializeField] int monsterHealth = 50;
    [SerializeField] int monsterDamage = 10;
    [SerializeField] GameObject rotatePlayerPoint;

    public bool isInvetoryOpen = false;
    private bool isSprinting = false;


    [SerializeField] private int maxStamina = 100;
    private int currentStatmina;
    [SerializeField] private int useStamina = 5;
    [SerializeField] private float regenTime = 1;

    private void Awake()
    {
        monsterInputSystem = GetComponent<MonsterInputSystem>();
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        Cursor.visible = isInvetoryOpen;
        currenSpeed = moveSpeed;
        sprintSpeed = moveSpeed * 3;

        playerInputActions = new PlayerInputActions();
        

    }
    private void OnEnable()
    {
        playerInputActions.Monster.Enable();
        playerInputActions.Monster.Movement.performed += Movement_performed;
        playerInputActions.Monster.Attack.performed += Attack_performed;
        playerInputActions.Monster.Attack.canceled += Attack_canceled;
        playerInputActions.Monster.Sprint.performed += Sprint_performed;
        playerInputActions.Monster.Sprint.canceled += Sprint_canceled;


    }
    private void OnDisable()
    {
        playerInputActions.Player.Disable();
        playerInputActions.Player.Movement.performed -= Movement_performed;
        playerInputActions.Player.Movement.performed -= Attack_performed;
        playerInputActions.Monster.Attack.canceled -= Attack_canceled;
        playerInputActions.Monster.Sprint.performed -= Sprint_performed;
        playerInputActions.Monster.Sprint.canceled -= Sprint_canceled;
    }

    private void Attack_performed(InputAction.CallbackContext context)
    {
        animator.SetTrigger("Attack");
        rotatePlayerPoint.GetComponent<BoxCollider>().enabled=true;
    }
    private void Attack_canceled(InputAction.CallbackContext context)
    {
        rotatePlayerPoint.GetComponent<BoxCollider>().enabled = false;
    }

    private void Movement_performed(InputAction.CallbackContext context)
    {
        inputMovement = context.ReadValue<Vector2>();
    }
    private void Sprint_performed(InputAction.CallbackContext context)
    {
        isSprinting = true;
    }
    private void Sprint_canceled(InputAction.CallbackContext context)
    {
        isSprinting = false;
    }


    private void Update()
    {
        
        inputMovement = playerInputActions.Monster.Movement.ReadValue<Vector2>();
        horizontalMovement = (transform.right * inputMovement.x + transform.forward * inputMovement.y);
        characterController.Move(horizontalMovement * currenSpeed * Time.deltaTime);

        if (isSprinting)
        {
            
            if (currentStatmina - useStamina >= 0)
            {
                currentStatmina -= useStamina;
                currenSpeed = sprintSpeed;
            }
            
        }
        else
        {
            currenSpeed = moveSpeed;
        }

        if (horizontalMovement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(horizontalMovement, Vector3.up);
            rotatePlayerPoint.transform.rotation = Quaternion.RotateTowards(rotatePlayerPoint.transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
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
    public void TakeDamage(int damage)
    {
        monsterHealth -= damage;
    }
    public int GetMonsterDamage()
    {
        return monsterDamage;
    }
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(regenTime);
    }
    
}
