using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenuButtons : MonoBehaviour {
    public void ButtonStart()
    {
        SceneManager.LoadScene(2);
    }
    public void ButtonSettings()
    {

    }
    public void ButtonExit()
    {
        Application.Quit();
    }
}
