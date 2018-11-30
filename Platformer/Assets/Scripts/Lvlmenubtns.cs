using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lvlmenubtns : MonoBehaviour {
    GameObject set;
    private void Awake()
    {
        set = Resources.Load("ComingSoon") as GameObject;
    }
    public void Scene1()
    {
         SceneManager.LoadScene("Ch1_lvl1");
    }
    public void Scene2()
    {
        if (Global.lvlsop[1] == true)
        {
            SceneManager.LoadScene("Ch1_lvl2");
        }
        else
        {
            Canvas ca = FindObjectOfType<Canvas>();
            Instantiate(set, ca.transform);
        }
    }
    public void Scene3()
    {
        if (Global.lvlsop[2] == true)
        {
            SceneManager.LoadScene("Scene3");
        }
        else
        {
            Canvas ca = FindObjectOfType<Canvas>();
            Instantiate(set, ca.transform);
        }
    }
    public void Scene4()
    {
        if (Global.lvlsop[3] == true)
        {
            SceneManager.LoadScene("Scene4");
        }
        else
        {
            Canvas ca = FindObjectOfType<Canvas>();
            Instantiate(set, ca.transform);
        }
    }
}
