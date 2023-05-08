using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor1 : MonoBehaviour {

    private Inventory inventory;
   
   private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    void Update()
    {
        if (inventory.isFull[0] && inventory.isFull[1] && inventory.isFull[2] && inventory.isFull[3])
        {
            Destroy(gameObject);
        }
    }
}