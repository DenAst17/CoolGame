using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRed : MonoBehaviour {
    public int damage = 20;
    void Start () {
        Destroy(this.gameObject, 20);
	}
}
