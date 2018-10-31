using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBlue : MonoBehaviour {
    public int damage = 5;
    void Start () {
        Destroy(this.gameObject, 40);
    }
}
