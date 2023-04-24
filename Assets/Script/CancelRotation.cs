using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelRotation : MonoBehaviour
{
    private Quaternion parentRotation;

    private void Start()
    {
        // Get the initial rotation of the parent
        parentRotation = transform.parent.rotation;

        // Reset the local rotation of the child
        transform.localRotation = Quaternion.identity;
    }

    private void LateUpdate()
    {
        // Override the parent's rotation
        transform.rotation = parentRotation;
    }
}