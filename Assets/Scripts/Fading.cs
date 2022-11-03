using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour
{

    public GameObject Canvas;
    private float timer = 4;

    void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer <= 0)
        {
            Canvas.SetActive(false);
        }
    }
}
