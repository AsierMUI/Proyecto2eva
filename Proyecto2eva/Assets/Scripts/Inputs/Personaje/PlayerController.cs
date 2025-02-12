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

            if (movementDirection.y > 0)
            {
                animator.SetTrigger(walkUpAnim);
            }
            else if (movementDirection.y < 0)
            {
                animator.SetTrigger(walkDownAnim);
            }
            else if (movementDirection.x < 0)
            {
                animator.SetTrigger(walkLeftAnim);
            }
            else if (movementDirection.x > 0)
            {
                animator.SetTrigger(walkRightAnim);
            }
        }

        else
        {
            animator.SetTrigger(idleAnim);
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
            animator.SetTrigger(attackUpAnim);
        }
        else if (movementDirection.y < 0)
        {
            animator.SetTrigger(attackDownAnim);
        }
        else if (movementDirection.x < 0)
        {
            animator.SetTrigger(attackLeftAnim);
        }
        else if (movementDirection.x > 0)
        {
            animator.SetTrigger(attackRightAnim);
        }

        StartCoroutine(AttackCooldown());
    }

    private System.Collections.IEnumerator AttackCooldown()
    {
        yield return new WaitForSeconds(1f);
        isAttacking = false;
    }
}
