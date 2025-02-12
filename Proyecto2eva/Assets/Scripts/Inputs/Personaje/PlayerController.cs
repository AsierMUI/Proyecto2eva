using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private Vector2 movement;
    Animator animator;
    private Vector2 input;
    private Vector2 movementDirection;
    private bool isAttacking = false;


    public string walkUpAnim;
    public string walkDownAnim;
    public string walkLeftAnim;
    public string walkRightAnim;
    public string attackUpAnim;
    public string attackDownAnim;
    public string attackLeftAnim;
    public string attackRightAnim;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        HandleInputs();

    }

    #region Input Methods
    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    #endregion


    private void HandleInputs()
    {
        if (isAttacking) return;

        movementDirection = new Vector2(Input.GetAxis("Horizontal"),
            Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("WalkUp");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetTrigger("WalkDown");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetTrigger("WalkLeft");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetTrigger("WalkRight");
        }

        if (Input.GetKeyDown(KeyCode.RightAlt)) 
        {
            HandleAttack();

        }
    }
    private void HandleAttack()
    {
        isAttacking = true;
        if (movementDirection.y > 0)
        {
            animator.SetTrigger("AttackUp");
        }
        else if (movementDirection.y < 0)
        {
            animator.SetTrigger("AttackDown");
        }
        else if (movementDirection.x < 0)
        {
            animator.SetTrigger("AttackLeft");
        }
        else if (movementDirection.x > 0)
        {
            animator.SetTrigger("AttackRight");
        }
        StartCoroutine(AttackCooldown());
    }
    private System.Collections.IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }

}
