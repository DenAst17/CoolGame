using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Water : MonoBehaviour {
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private int border = 4;
    [SerializeField]
    private Vector3 dir;
    private void Update()
    {
        Transform Tt = GetComponent<Transform>();
        Tt.position = new Vector3(transform.position.x+speed*Time.deltaTime,transform.position.y+(float)Math.Sin(Time.time * Math.PI * 1.3) / -100, transform.position.z);
    }
}
