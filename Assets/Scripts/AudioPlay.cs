using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    bool inAudio = false;
    public GameObject JumpScare;
    public GameObject JumpScareImage;
    public GameObject HealthImage;
    float scareTimer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //count = 1;
            inAudio = true;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (inAudio)
        {
            if (scareTimer <= 3)
            {
                JumpScareImage.SetActive(true);
            }
            JumpScare.SetActive(true);
            scareTimer += Time.deltaTime;
            HealthImage.SetActive(false);

        }

        if (scareTimer >= 3)
        {
            inAudio = false;
            HealthImage.SetActive(true);
            scareTimer = 4;
        }

        if (inAudio == false)
        {
            JumpScareImage.SetActive(false);
        }
    }
}
