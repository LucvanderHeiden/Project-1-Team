using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class L2_chase : MonoBehaviour
{
    private GameMaster gm;
    
    string[] DieTag = {"Die"};
    
    void Start()
    {
        // gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        // transform.position = gm.lastCheckPointPos;
    }

    void OnTriggerEnter2D(Collider2D Col)
    {
        if(DieTag.Any(element => element == Col.tag)){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
