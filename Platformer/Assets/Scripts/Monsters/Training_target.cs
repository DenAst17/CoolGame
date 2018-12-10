using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Training_target : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
