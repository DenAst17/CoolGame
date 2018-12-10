using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour {
    GameObject go;
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private GameObject Targetcamera;
    private Vector3 poz;
    [SerializeField]
    private float leyer = 1;
    private float poz1;
    private float poz2;
    [SerializeField]
    private GameObject sup;
    private void Awake()
    {
        go = this.gameObject;
        poz = Targetcamera.transform.position;
        poz.z = leyer+2;
        poz1 = Targetcamera.transform.position.x;
        poz2 = Targetcamera.transform.position.x;
    }
    private void Update()//21.1862      sup.transform.position = new Vector3(go.transform.position.x + 21.1862f, go.transform.position.y, go.transform.position.z);    0.11
    {
        poz1 = poz2;
        poz2 = Targetcamera.transform.position.x;
        go.transform.position = new Vector3(go.transform.position.x + (poz2 - poz1) * speed, Targetcamera.transform.position.y, poz.z);
        if (go.transform.position.x < Hero.tr.position.x + 0.11f && go.transform.position.x > Hero.tr.position.x - 0.11f)
        {
            Debug.Log("Cach1");
            if (poz2 - poz1 > 0)
            {
                sup.transform.position = new Vector3(go.transform.position.x + 21.1862f, go.transform.position.y, go.transform.position.z);
            }
            else if (poz2 - poz1 < 0)
            {
                sup.transform.position = new Vector3(go.transform.position.x - 21.1862f, go.transform.position.y, go.transform.position.z);
            }
        }
        else if (sup.transform.position.x < Hero.tr.position.x + 0.11f && sup.transform.position.x > Hero.tr.position.x - 0.11f)
        {
            Debug.Log("Cach2");
            if (poz2 - poz1 > 0)
            {
                go.transform.position = new Vector3(sup.transform.position.x + 21.1862f, sup.transform.position.y, sup.transform.position.z);
            }
            else if (poz2 - poz1 < 0)
            {
                go.transform.position = new Vector3(go.transform.position.x - 21.1862f, go.transform.position.y, go.transform.position.z);
            }
        }
    }
}
