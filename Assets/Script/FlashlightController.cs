using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private Vector2 lastMovement = Vector2.zero;

    void Update()
    {
        // Get the input axis values for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Store the last movement direction
        if (horizontalInput != 0 || verticalInput != 0)
        {
            lastMovement = new Vector2(horizontalInput, verticalInput);
        }

        // Calculate the angle based on the last movement direction
        float angle = Mathf.Atan2(lastMovement.y, lastMovement.x) * Mathf.Rad2Deg;

        // Rotate the flashlight object around the z-axis
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}