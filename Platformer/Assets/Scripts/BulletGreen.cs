using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGreen : MonoBehaviour {
    public int damage = 10;
	void Start () {
        Destroy(this.gameObject, 60);
    }
}
