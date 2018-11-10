using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VisualLevelMenu : MonoBehaviour {
    public void BacktoMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void Save()
    {

    }
    public void Sound()
    {

    }
    public void Contact()
    {
        SceneManager.LoadScene(0);
    }
}
