using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;

    private Vector3 previousPosition;

    private void Start()
    {
        previousPosition = transform.position;
    }

    private void Update()
    {
        // Get the current position of the GameObject
        Vector3 currentPosition = transform.position;

        // Calculate the movement direction based on the difference between the current position and the previous position
        Vector3 direction = currentPosition - previousPosition;

        // Update the previous position to be the current position
        previousPosition = currentPosition;

        // Determine the direction based on the movement direction
        if (direction.y > 0.01)
        {
            animator.Play("killer_up");
        }
        else if (direction.y < -0.01)
        {
            animator.Play("killer_down");
        }
        else if (direction.x < 0)
        {
            animator.Play("killer_left");
        }
        else if (direction.x > 0)
        {
            animator.Play("killer_right");
        }
    }
}


