using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BorderDown : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player" && FindObjectOfType<Builder>())
        {
            Hero.tr.position = new Vector3(Builder.perx,Builder.pery,transform.position.z);
        }
        else if (collision.gameObject.tag == "player" && FindObjectOfType<LevelProporties>())
        {
            LevelProporties tl = FindObjectOfType<LevelProporties>();
            Hero.tr.position = tl.StartPozition;
        }
        else if(collision.gameObject.tag == "player")
        {
            Hero.heart = 100f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (collision.gameObject.tag == "Zombie")
        {
            GameObject.Destroy(collision.gameObject);
        }
    }
}
