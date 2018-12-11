using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    [SerializeField]
    private GameObject target;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            collision.gameObject.transform.position = target.transform.position;
        }
    }
}
