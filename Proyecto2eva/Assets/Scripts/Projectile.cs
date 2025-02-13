using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;
    private Rigidbody2D rb;
    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        rb = GetComponent<Rigidbody2D>();

        LaunchProjectile();
    }

    private void LaunchProjectile()
   
        {
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            rb.velocity = directionToPlayer * speed;
        StartCoroutine(DestroyProjectile());
        }

    IEnumerator DestroyProjectile()
    {
        float destroyTime = 5f;
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
    private void OnCollisionEnter2D()
    {
        Destroy(gameObject);
    }


}
