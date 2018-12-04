using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauze : MonoBehaviour {

    public void Continue()
    {
        Time.timeScale = 1;
        GameObject.Destroy(GameObject.FindGameObjectWithTag("Pause"));
    }
    public void Restart()
    {
        Hero.heart = 100f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
        SceneManager.LoadScene("SelectLevel");
    }
}
