using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]
    public Transform target;
    [SerializeField]
    private float lensh = -10;
    private void Awake()
    {
        if (!target) target = FindObjectOfType<Hero>().transform;
        transform.position = new Vector3(target.position.x,target.position.y+1f,lensh);
    }

    private void Update()
    {
        Vector3 poz = target.position; poz.z = lensh; poz.y += 1.2f; 
        speed = Vector3.Distance(transform.position, target.position)/2;
        transform.position = Vector3.Lerp(transform.position, poz, speed * Time.deltaTime);
    }
}
