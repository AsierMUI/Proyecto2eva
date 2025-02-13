using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] waypoints;

    private int currentWaypoint;

    void Update()
    {
        if(transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
        }
        else
        {
            currentWaypoint++;
        }
    }
}
