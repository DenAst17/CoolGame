using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pauze : MonoBehaviour {

    public void Continue()
    {
        Time.timeScale = 1;
        GameObject.Destroy(GameObject.FindGameObjectWithTag("Pause"));
        GameObject.Destroy(GameObject.FindGameObjectWithTag("hug"));
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
