using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;

    public GameObject jumpscareScreen;
    private SpriteRenderer jumpscareSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        jumpscareSpriteRenderer = jumpscareScreen.GetComponent<SpriteRenderer>();
        jumpscareSpriteRenderer.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<Collider2D>().IsTouching(enemy.GetComponent<Collider2D>()))
        {
            jumpscareSpriteRenderer.enabled = true;
        }
    }
}
