using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AINavigation : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    private Transform currentTarget;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        // Set initial target to pointA
        currentTarget = pointA;
        agent.SetDestination(currentTarget.position);
    }

    void Update()
    {
        // Check if the agent is close to the current target
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            // Switch target
            if (currentTarget == pointA)
            {
                currentTarget = pointB;
            }
            else
            {
                currentTarget = pointA;
            }
            agent.SetDestination(currentTarget.position);
        }

        // Maintain z position
        Vector3 position = transform.position;
        position.z = 0f;
        transform.position = position;

        // Update rotation to face the direction of movement
        Vector3 direction = agent.desiredVelocity;
        if (direction.sqrMagnitude > 0.01f) // Check if there is significant movement
        {
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // Subtract 90 to correct the sprite's forward direction
        }
    }
}
