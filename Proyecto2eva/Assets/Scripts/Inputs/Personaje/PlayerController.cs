using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    private PlayerInput playerInput;
    private Vector2 movement;
    private Animator animator;
    private float movimientoX;
    private float movimientoY;
    private bool isAttacking;

    public int currentPoints;
    public int winPoints;
    public GameObject winGoal;


    public SceneChanger sceneManager;
    public int sceneToLoad;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //ataque
        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            animator.Play("Ataque");
            isAttacking = true;
        }

        Movimiento();
        MoveCharacter();


        if(currentPoints <0) { currentPoints = 0;}
        if (currentPoints >= winPoints) { winGoal.SetActive(true); }
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
    void Movimiento()
    {
        //animacion movimiento
        if (isAttacking) return;

        movimientoX = Input.GetAxisRaw("Horizontal");
        movimientoY = Input.GetAxisRaw("Vertical");

        animator.SetFloat("MovimientoX", movimientoX);
        animator.SetFloat("MovimientoY", movimientoY);

        if (movimientoX != 0 || movimientoY != 0)
        {
            animator.SetFloat("UltimoX", movimientoX);
            animator.SetFloat("UltimoY", movimientoY);
        }
    }

    void FinAtaque()
    {
        isAttacking = false;
    }
    private void OnTriggerEnter(Collision colision)
    {
        if (colision.gameObject.CompareTag("Enemigo"))
        {
            SceneManager.LoadScene(11);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
            currentPoints += 1;
            other.gameObject.SetActive(false);
        }
        if(other.gameObject.CompareTag("Finish"))
        {
            WinCall();
            other.gameObject.SetActive(false);
        }
    }
    void WinCall()
    {
        sceneManager.SceneLoader(sceneToLoad);
    }
}
