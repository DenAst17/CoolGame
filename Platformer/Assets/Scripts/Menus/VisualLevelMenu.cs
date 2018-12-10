using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VisualLevelMenu : MonoBehaviour {
    public void BacktoMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void Save()
    {

    }

    public void Challenge()
    {
        SceneManager.LoadScene("Training_lvl");
    }
    public void Contact()
    {
        SceneManager.LoadScene("Polygon");
    }
}
