using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Water : MonoBehaviour {
    [SerializeField]
    private float speed = 2;
    [SerializeField]
    private int border = 4;
    private float time = 0.016f;
    private void Update()
    {
        if (Time.timeScale != 0) {
            time += 0.0155f;
            Transform Tt = GetComponent<Transform>();
            Tt.position = new Vector3(transform.position.x, transform.position.y + (float)Math.Sin(time * Math.PI) / -100, transform.position.z);
        }
    }
}
