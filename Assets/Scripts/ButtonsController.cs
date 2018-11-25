using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour {

    public void LoadStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadExit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
        Camera.main.backgroundColor = new Color32(55, 44, 100, 255);
        Camera.main.GetComponent<CameraController>().enabled = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
        Camera.main.backgroundColor = new Color32(55, 44, 100, 255);
    }

}
