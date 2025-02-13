using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Animator animator;
    public float shootDuration = 2f;

    private bool isShooting = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightAlt) && !isShooting)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        isShooting = true;
        animator.SetTrigger("Attacking");


        yield return new WaitForSeconds(shootDuration);
        isShooting = false;

    }



}
