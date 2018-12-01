using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Water : MonoBehaviour {
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private int border = 4;
    private void Update()
    {
        Transform Tt = GetComponent<Transform>();
        Tt.position = new Vector3(transform.position.x,transform.position.y+(float)Math.Sin(Time.time * Math.PI) / -100, transform.position.z);
    }
}
