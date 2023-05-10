using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Check if the color of the SpriteRenderer matches the required colo
            // Destroy the collided game object (the player)
            SceneManager.LoadScene("cutscene_ending");
            Debug.Log("Objects are colliding!");
        }
    }
}
