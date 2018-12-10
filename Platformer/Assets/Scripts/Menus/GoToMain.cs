using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToMain : MonoBehaviour {
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
