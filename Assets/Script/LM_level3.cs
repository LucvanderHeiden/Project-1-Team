using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LM_level3 : MonoBehaviour
{
     public void StartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 15);
    }
}
