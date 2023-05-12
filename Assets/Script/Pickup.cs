using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private Inventory inventory;
    public GameObject itemButton;
    public AudioClip music;
    // public GameObject effect;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
                
        Debug.Log("Inventory: " + inventory);
        Debug.Log("ItemButton: " + itemButton);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            AudioSource.PlayClipAtPoint(music, transform.position);
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                Debug.Log("isFull[" + i + "]: " + inventory.isFull[i]);
                if (inventory.isFull[i] == false) { // check whether the slot is EMPTY
                    // Instantiate(effect, transform.position, Quaternion.identity);
                    inventory.isFull[i] = true; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                    Destroy(gameObject);
                    break;
                }
            }
        }
        
    }
}

// Bron: https://www.youtube.com/watch?v=DLAIYSMYy2g