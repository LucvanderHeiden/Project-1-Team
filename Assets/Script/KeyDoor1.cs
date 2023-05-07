using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor1 : MonoBehaviour {

    private Inventory inventory;
   
    private void OnColliderEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Door")
        {
            inventory.isFull[4] = true;
            Destroy(gameObject);
        }
    }

}