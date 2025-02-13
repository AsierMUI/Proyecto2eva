using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float minDistance;
    private int numeroAleatorio;
    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        numeroAleatorio = Random.Range(0, waypoints.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoints[numeroAleatorio].position, speed * Time.deltaTime);
        
        if (Vector2.Distance(transform.position, waypoints[numeroAleatorio].position) < minDistance)
        {
            numeroAleatorio = Random.Range(0,waypoints.Length);
            FLip();
        }
    }
    private void FLip()
    {
        if (transform.position.x < waypoints[numeroAleatorio].position.x)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX= true;
        }
    }
}
