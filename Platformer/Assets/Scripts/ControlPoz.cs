using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPoz : MonoBehaviour {
    public int serialnumber = 0;
    public bool open = false;
    public Transform mt;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            open = true;
        }
    }
    private void Awake()
    {
        if (serialnumber != 0 && !Global.Respawns) { GameObject.Destroy(this.gameObject); }
    }
}
