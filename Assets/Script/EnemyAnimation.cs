using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    public Animator animator;
    public GameObject enemy;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //enemyRB = enemy.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Get the velocity of the Rigidbody2D
        Vector2 velocity = rb.velocity;
        //Vector2 velocity = enemyRB.velocity;

        // Determine the direction based on the velocity
        if (velocity.y > 0)
        {
            animator.Play("killer_up");
        }
        else if (velocity.y < 0)
        {
            animator.Play("killer_down");
        }
        else if (velocity.x < 0)
        {
            animator.Play("killer_left");
        }
        else if (velocity.x > 0)
        {
            animator.Play("killer_right");
        }

        Debug.Log(velocity);
    }
}

