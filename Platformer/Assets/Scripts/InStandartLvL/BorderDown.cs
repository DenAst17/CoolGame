using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BorderDown : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && FindObjectOfType<Builder>())
        {
            Global.respawns++;
            Hero.tr.position = new Vector3(Builder.perx,Builder.pery,transform.position.z);
        }
        else if (collision.gameObject.tag == "player" && FindObjectOfType<LevelProporties>())
        {
            Global.respawns++;
            LevelProporties tl = FindObjectOfType<LevelProporties>();
            ControlPoz[] cp = FindObjectsOfType<ControlPoz>();
            int max = 0;
            for (int i = 0; i < cp.Length; i++)
            {
                if (max<=cp[i].serialnumber && cp[i].open) { max = cp[i].serialnumber; }
            }
            for (int i = 0; i < cp.Length; i++)
            {
                if (max == cp[i].serialnumber) { Hero.tr.position = cp[i].mt; break; }
            }
        }
        else if(collision.gameObject.tag == "player")
        {
            Global.respawns++;
            Hero.heart = 100f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collision.gameObject.tag == "Zombie")
        {
            GameObject.Destroy(collision.gameObject);
        }
    }
}
