using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject DeathScreenPanel;
    public GameObject HealthImage;

    public void Update()
    {
        if (DeathScreenPanel.activeSelf)
        {
            HealthImage.SetActive(false);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }


    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgain()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
}
