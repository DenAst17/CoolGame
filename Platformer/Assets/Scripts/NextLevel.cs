using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevel : MonoBehaviour {
    public void NextLevelGo()
    {
        SaveProgress();
        LevelProporties lp = FindObjectOfType<LevelProporties>();
        SceneManager.LoadScene(lp.NextLevel);
    }

    public void Restart()
    {
        SaveProgress();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        SaveProgress();
        SceneManager.LoadScene("SelectLevel");
    }

    private void SaveProgress()
    {

    }
}
