using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickBtn : MonoBehaviour {
    [SerializeField]
    public Toggle bl;
    [SerializeField]
    public Toggle gr;
    [SerializeField]
    public Toggle rd;

    public void Blue()
    {
        if (bl.enabled == true)
        {

            gr.enabled = false;
            rd.enabled = false;
            rd.Select();
        }
    }
    public void Green()
    {
        if (gr.enabled == true)
        {

            rd.enabled = false;
            bl.enabled = false;
        }
    }
    public void Red()
    {
        if (rd.enabled == true)
        {

            bl.enabled = false;
            gr.enabled = false;
        }
    }
}
