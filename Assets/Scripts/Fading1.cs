using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading1 : MonoBehaviour
{

    public GameObject Canvas;
    private float timer = 7;

    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            Canvas.SetActive(true);
        }
    }


    public void BackToMain()
    {
        SceneManager.LoadScene(0);
    }
}
