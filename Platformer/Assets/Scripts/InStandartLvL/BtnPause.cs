using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPause : MonoBehaviour {
    private GameObject set;
    private GameObject hug;
    private void Awake()
    {
        set = Resources.Load("Pause") as GameObject;
        hug = Resources.Load("Hug") as GameObject;
    }
    public void Click()
    {
        if (!GameObject.FindGameObjectWithTag("Pause"))
        {
            Time.timeScale = 0;
            Canvas ca = FindObjectOfType<Canvas>();
            Instantiate(hug, ca.transform);
            Instantiate(set, ca.transform);
        }
    }
}
