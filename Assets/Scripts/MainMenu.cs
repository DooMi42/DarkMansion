using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Canvas;

    public void Play()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Credits()
    {
        Canvas.SetActive(true);
    }

    public void Back()
    {
        Canvas.SetActive(false);
    }

}
