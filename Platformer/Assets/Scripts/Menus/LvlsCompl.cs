using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LvlsCompl : MonoBehaviour {
    private Text txt;
    private void Awake()
    {
        txt = GetComponent<Text>();
    }
    void Update () {
        txt.text = "Levels completed: " + Global.levelscomp;
	}
}
