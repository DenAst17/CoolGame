using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class Close : MonoBehaviour {
    Slider tg;
    GameObject go;
    public void Closed()
    {
        if (GameObject.FindGameObjectWithTag("jo"))
        {
            go = GameObject.FindGameObjectWithTag("jo");
            tg = go.GetComponent<Slider>();
            if (go.tag == "jo")
            {
                Global.difficulty = Convert.ToInt32(tg.value);
            }
        }
        GameObject.Destroy(GameObject.FindGameObjectWithTag("Settings"));
    }
}
