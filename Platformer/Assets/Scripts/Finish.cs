using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour {
    [SerializeField]
    private int coins = 5;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (Hero.coins >= coins)
            {
                VisualInterfase.Win();
            }
        }
    }
}
