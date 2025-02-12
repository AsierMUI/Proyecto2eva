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
    private Animator animator;
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
    public string idleAnim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInputs();
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
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

        movementDirection = movement;

        if (movementDirection.sqrMagnitude > 0)
        {
            animator.SetBool("IsMoving", true);

            if (movementDirection.y > 0)
            {
                animator.SetBool(walkUpAnim, true);
                animator.SetBool(walkDownAnim, false);
                animator.SetBool(walkLeftAnim, false);
                animator.SetBool(walkRightAnim, false);
            }
            else if (movementDirection.y < 0)
            {
                animator.SetBool(walkUpAnim, false);
                animator.SetBool(walkDownAnim, true);
                animator.SetBool(walkLeftAnim, false);
                animator.SetBool(walkRightAnim, false);
            }
            else if (movementDirection.x < 0)
            {
                animator.SetBool(walkUpAnim, false);
                animator.SetBool(walkDownAnim, false);
                animator.SetBool(walkLeftAnim, true);
                animator.SetBool(walkRightAnim, false);
            }
            else if (movementDirection.x > 0)
            {
                animator.SetBool(walkUpAnim, false);
                animator.SetBool(walkDownAnim, false);
                animator.SetBool(walkLeftAnim, false);
                animator.SetBool(walkRightAnim, true);
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
            animator.SetBool(walkUpAnim, false);
            animator.SetBool(walkDownAnim, false);
            animator.SetBool(walkLeftAnim, false);
            animator.SetBool(walkRightAnim, false);
            animator.SetBool(idleAnim, true);

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            HandleAttack();
        }
    }

    private void HandleAttack()
    {
        isAttacking = true;
        animator.SetBool("IsAttacking", true);

        if (movementDirection.y > 0)
        {
            animator.SetBool(attackUpAnim, true);
            animator.SetBool(attackDownAnim, false);
            animator.SetBool(attackLeftAnim, false);
            animator.SetBool(attackRightAnim, false);

        }
        else if (movementDirection.y < 0)
        {
            animator.SetBool(attackUpAnim, false);
            animator.SetBool(attackDownAnim, true);
            animator.SetBool(attackLeftAnim, false);
            animator.SetBool(attackRightAnim, false);
        }
        else if (movementDirection.x < 0)
        {
            animator.SetBool(attackUpAnim, false);
            animator.SetBool(attackDownAnim, false);
            animator.SetBool(attackLeftAnim, true);
            animator.SetBool(attackRightAnim, false);
        }
        else if (movementDirection.x > 0)
        {
            animator.SetBool(attackUpAnim, false);
            animator.SetBool(attackDownAnim, false);
            animator.SetBool(attackLeftAnim, false);
            animator.SetBool(attackRightAnim, true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            animator.SetBool(attackUpAnim, false);
            animator.SetBool(attackDownAnim, false);
            animator.SetBool(attackLeftAnim, false);
            animator.SetBool(attackRightAnim, false);
        }

        StartCoroutine(AttackCooldown());
    }

    private System.Collections.IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(5f);
        animator.SetBool("IsAttacking", false);
        isAttacking = false;
    }
}
