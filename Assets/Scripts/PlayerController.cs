using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;

    public Transform enemy; // The enemy GameObject
    private float distance; // The current distance between the player and the enemy

    Vector2 movementInput;
    Rigidbody2D rb;
    Animator animator;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        TrackDistance();
    }

    private void FixedUpdate()
    {
        if (movementInput != Vector2.zero)
        {
            // Calculate the direction of movement
            Vector2 direction = movementInput.normalized;

            // Check if the player is moving more in the x direction or y direction
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                // Player is moving horizontally
                if (direction.x > 0)
                {
                    // Player is moving right
                    // Play the "WalkRight" animation
                    animator.Play("player_right");
                }
                else
                {
                    // Player is moving left
                    // Play the "WalkLeft" animation
                    animator.Play("player_left");
                }
            }
            else
            {
                // Player is moving vertically
                if (direction.y > 0)
                {
                    // Player is moving up
                    // Play the "WalkUp" animation
                    animator.Play("playeranimation");
                }
                else
                {
                    // Player is moving down
                    // Play the "WalkDown" animation
                    animator.Play("player_down");
                }
            }

            // Check for collisions and move the player
            int count = rb.Cast(
                movementInput,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0)
            {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            animator.Play("player_idle");
        }
    }


    void OnMove(InputValue movementValue)
    {
        movementInput = movementValue.Get<Vector2>();
    }


    void TrackDistance()
    {
        distance = Vector3.Distance(transform.position, enemy.position);
    }
}
