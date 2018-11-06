using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenu : MonoBehaviour {
    [SerializeField]
    Image vis1;
    [SerializeField]
    Image vis2;
    [SerializeField]
    Sprite p1;
    [SerializeField]
    Sprite p2;
    [SerializeField]
    Sprite p3;
    [SerializeField]
    Sprite p4;
    [SerializeField]
    Sprite p5;
    [SerializeField]
    Sprite p6;
    [SerializeField]
    Sprite p7;
    [SerializeField]
    Sprite p8;
    [SerializeField]
    Sprite p9;
    [SerializeField]
    public float t = 60;
    [SerializeField]
    public float ct = 10;
    public bool fo = true;
    [SerializeField]
    Material c1;
    [SerializeField]
    Material c2;
    [SerializeField]
    Material from;
    [SerializeField]
    Material end;
    private void Update()
    {
        if (t<=0)
        {
            t = 60;
            int r = Random.Range(1,9);
            swich(r);
        }
        t-=Time.deltaTime*10;
    }
    void swich(int s)
    {
        if (fo)
        {
            fo = false;
            switch (s)
            {
                case 1:
                    vis2.sprite = p1;
                    break;
                case 2:
                    vis2.sprite = p2;
                    break;
                case 3:
                    vis2.sprite = p3;
                    break;
                case 4:
                    vis2.sprite = p4;
                    break;
                case 5:
                    vis2.sprite = p5;
                    break;
                case 6:
                    vis2.sprite = p6;
                    break;
                case 7:
                    vis2.sprite = p7;
                    break;
                case 8:
                    vis2.sprite = p8;
                    break;
                case 9:
                    vis2.sprite = p9;
                    break;
                default:
                    vis2.sprite = p1;
                    break;
            }
            c1.Lerp(from, end, ct);
            c2.Lerp(end, from, ct);
        }
        else
        {
            fo = true;
            switch (s)
            {
                case 1:
                    vis1.sprite = p1;
                    break;
                case 2:
                    vis1.sprite = p2;
                    break;
                case 3:
                    vis1.sprite = p3;
                    break;
                case 4:
                    vis1.sprite = p4;
                    break;
                case 5:
                    vis1.sprite = p5;
                    break;
                case 6:
                    vis1.sprite = p6;
                    break;
                case 7:
                    vis1.sprite = p7;
                    break;
                case 8:
                    vis1.sprite = p8;
                    break;
                case 9:
                    vis1.sprite = p9;
                    break;
                default:
                    vis1.sprite = p1;
                    break;
            }
            c2.Lerp(from, end, ct);
            c1.Lerp(end, from, ct);
        }
    }
}
