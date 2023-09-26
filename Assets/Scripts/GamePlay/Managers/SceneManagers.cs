using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    
    void Update()
    {
        if (GameManager.instance.isGameover && Input.GetMouseButtonDown(0))
        {
            GameManager.instance.IsPause();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            SceneManager.LoadScene("GameReady");
        }
    }
}
