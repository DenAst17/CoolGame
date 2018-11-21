using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour {
    [SerializeField]
    public int difficulty = 1;
    [SerializeField]
    public int levellensth = 80;
    [SerializeField]
    int level = 1;
    [SerializeField]
    public int n = 70;
    [SerializeField]
    public int m = 20;
    [SerializeField]
    public int xmas = 0;
    [SerializeField]
    public int ymas = 0;
    public float xpl = 0;
    public float ypl = 0;
    [SerializeField]
    public int[,] vs;
    [SerializeField]
    public float[,,] cor;
    public GameObject StartPoz;
    private GameObject block_middle;
    private GameObject block_Left;
    private GameObject block_Left_Down;
    private GameObject block_Left_Up;
    private GameObject block_Right;
    private GameObject block_Right_Down;
    private GameObject block_Right_Up;
    private GameObject block_Down;
    private GameObject block_Up;
    private GameObject Platform_Left;
    private GameObject Platform_Middle;
    private GameObject Platform_Right;
    private GameObject block_Left_to_Up1;
    private GameObject block_Left_to_Up2;
    private GameObject block_Right_to_Up1;
    private GameObject block_Right_to_Up2;
    void LevelvsSummer()
    {
        block_middle = GameObject.Find("Main/SBlock_M");//1
        block_Left = GameObject.Find("Main/SBlock_L");//2
        block_Right = GameObject.Find("Main/SBlock_R");//3
        block_Down = GameObject.Find("Main/SBlock_D");//4
        block_Up = GameObject.Find("Main/SBlock_M_Up");//5
        Platform_Left = GameObject.Find("Main/Platform_L");//6
        Platform_Middle = GameObject.Find("Main/Platform_M");//7
        Platform_Right = GameObject.Find("Main/Platform_R");//8
        block_Left_Down = GameObject.Find("Main/SBlock_L_D");//9
        block_Left_Up = GameObject.Find("Main/SBlock_L_Up");//10
        block_Right_Down = GameObject.Find("Main/SBlock_R_D");//11
        block_Right_Up = GameObject.Find("Main/SBlock_R_Up");//12
        block_Left_to_Up1 = GameObject.Find("Main/SBlock_LL-Up");//13
        block_Left_to_Up2 = GameObject.Find("Main/SBlock_L-Up");//14
        block_Right_to_Up1 = GameObject.Find("Main/SBlock_R-Up");//15
        block_Right_to_Up2 = GameObject.Find("Main/SBlock_RR-Up");//16
    }
    private void Awake()
    {
        switch (level)
        {
            case 1:
                LevelvsSummer();
                break;
            default:
                LevelvsSummer();
                break;
        }
        /*
         Create massive
        */
        //Create symbols
        for (int i = 1; i < n-1; i++)
        {
            for (int j = 1; j < 2*m; j++)
            {
                if (vs[i, j] != 0)
                {
                    if (vs[i, j] == 20)
                    {
                        if (vs[i - 1, j] == 0)
                        {//                                    |            |            |            @           @|               |@         
                            vs[i, j] = 6;//                   @|--        --|--        --|@         --|--        --|--           --|--                                
                        }//                                    |            @            |            |            |               |              
                        else if (vs[i + 1, j] == 0)//      (x-1 , y) && (x , y-1) && (x+1 , y) && (x , y+1) && (x-1 , y-1) && (x+1 , y-1)
                        {
                            vs[i, j] = 8;
                        }
                        else
                        {
                            vs[i, j] = 7;
                        }
                    }
                    else if (vs[i, j] == 1)
                    {
                        if (vs[i - 1, j] == 0/*1*/ && vs[i, j - 1] != 0/*2*/ && vs[i + 1, j] != 0/*3*/ && vs[i, j + 1] == 0/*4*/ && vs[i - 1, j - 1] == 0/*5*/ && vs[i + 1, j - 1] == 0/*6*/)
                        {
                            vs[i, j] = 10;
                        }
                        else if (vs[i - 1, j] == 0/*1*/ && vs[i, j - 1] != 0/*2*/ && vs[i + 1, j] != 0/*3*/ && vs[i, j + 1] != 0/*4*/ && vs[i - 1, j - 1] == 0/*5*/ && vs[i + 1, j - 1] != 0/*6*/)
                        {
                            vs[i, j] = 2;
                        }
                        else if (vs[i - 1, j] != 0/*1*/ && vs[i, j - 1] != 0/*2*/ && vs[i + 1, j] != 0/*3*/ && vs[i, j + 1] != 0/*4*/ && vs[i - 1, j - 1] == 0/*5*/ && vs[i + 1, j - 1] != 0/*6*/)
                        {
                            vs[i, j] = 14;
                        }
                        else if (vs[i - 1, j] != 0/*1*/ && vs[i, j - 1] != 0/*2*/ && vs[i + 1, j] != 0/*3*/ && vs[i, j + 1] != 0/*4*/ && vs[i - 1, j - 1] != 0/*5*/ && vs[i + 1, j - 1] != 0/*6*/)
                        {
                            vs[i, j] = 1;
                        }
                        else if (vs[i - 1, j] != 0/*1*/ && vs[i, j - 1] != 0/*2*/ && vs[i + 1, j] != 0/*3*/ && vs[i, j + 1] == 0/*4*/ && vs[i - 1, j - 1] == 0/*5*/ && vs[i + 1, j - 1] != 0/*6*/)
                        {
                            vs[i, j] = 13;
                        }
                        else if (vs[i - 1, j] == 0/*1*/ && vs[i, j - 1] == 0/*2*/ && vs[i + 1, j] != 0/*3*/ && vs[i, j + 1] == 0/*4*/ && vs[i - 1, j - 1] == 0/*5*/ && vs[i + 1, j - 1] == 0/*6*/)
                        {
                            vs[i, j] = 10;
                        }
                        else if (vs[i - 1, j] == 0/*1*/ && vs[i, j - 1] == 0/*2*/ && vs[i + 1, j] != 0/*3*/ && vs[i, j + 1] != 0/*4*/ && vs[i - 1, j - 1] == 0/*5*/ && vs[i + 1, j - 1] != 0/*6*/)
                        {
                            vs[i, j] = 9;
                        }
                        else if (vs[i - 1, j] != 0/*1*/ && vs[i, j - 1] == 0/*2*/ && vs[i + 1, j] != 0/*3*/ && vs[i, j + 1] != 0/*4*/ && vs[i - 1, j - 1] != 0/*5*/ && vs[i + 1, j - 1] != 0/*6*/)
                        {
                            vs[i, j] = 4;
                        }
                        else if (vs[i - 1, j] != 0/*1*/ && vs[i, j - 1] == 0/*2*/ && vs[i + 1, j] == 0/*3*/ && vs[i, j + 1] != 0/*4*/ && vs[i - 1, j - 1] != 0/*5*/ && vs[i + 1, j - 1] == 0/*6*/)
                        {
                            vs[i, j] = 11;
                        }
                        else if (vs[i - 1, j] != 0/*1*/ && vs[i, j - 1] != 0/*2*/ && vs[i + 1, j] == 0/*3*/ && vs[i, j + 1] != 0/*4*/ && vs[i - 1, j - 1] != 0/*5*/ && vs[i + 1, j - 1] == 0/*6*/)
                        {
                            vs[i, j] = 3;
                        }
                        else if (vs[i - 1, j] != 0/*1*/ && vs[i, j - 1] != 0/*2*/ && vs[i + 1, j] == 0/*3*/ && vs[i, j + 1] == 0/*4*/ && vs[i - 1, j - 1] == 0/*5*/ && vs[i + 1, j - 1] == 0/*6*/)
                        {
                            vs[i, j] = 12;
                        }
                        else if (vs[i - 1, j] != 0/*1*/ && vs[i, j - 1] != 0/*2*/ && vs[i + 1, j] != 0/*3*/ && vs[i, j + 1] == 0/*4*/ && vs[i - 1, j - 1] != 0/*5*/ && vs[i + 1, j - 1] == 0/*6*/)
                        {
                            vs[i, j] = 15;
                        }
                        else if (vs[i - 1, j] != 0/*1*/ && vs[i, j - 1] != 0/*2*/ && vs[i + 1, j] != 0/*3*/ && vs[i, j + 1] != 0/*4*/ && vs[i - 1, j - 1] != 0/*5*/ && vs[i + 1, j - 1] == 0/*6*/)
                        {
                            vs[i, j] = 16;
                        }
                        else if (vs[i - 1, j] != 0/*1*/ && vs[i, j - 1] != 0/*2*/ && vs[i + 1, j] != 0/*3*/ && vs[i, j + 1] == 0/*4*/ && vs[i - 1, j - 1] == 0/*5*/ && vs[i + 1, j - 1] == 0/*6*/)
                        {
                            vs[i, j] = 5;
                        }
                    }
                }
                else if (vs[i, j] == 100)
                {
                    ymas = j-1;
                    xmas = i-1;
                }
            }
        }
        cor[xmas, ymas, 0] = StartPoz.transform.position.x;
        cor[xmas, ymas, 1] = StartPoz.transform.position.y;
        //Right-Down
        for (int i = ymas; i < 2*m; i++)
        {
            for (int j = xmas; j < n; j++)
            {
                cor[j, i, 0] = StartPoz.transform.position.x + xpl;
                cor[j, i, 1] = StartPoz.transform.position.y + ypl;
                xpl++;
            }
            xpl = 0;
            ypl++;
        }ypl = 0; xpl = 0;
        //Left-Up
        for (int i = ymas; i > 0; i--)
        {
            for (int j = xmas; j > 0; j--)
            {
                cor[j, i, 0] = StartPoz.transform.position.x + xpl;
                cor[j, i, 1] = StartPoz.transform.position.y + ypl;
                xpl--;
            }
            xpl = 0;
            ypl--;
        }ypl = 0; xpl = 0;
        //Left-Down
        for (int i = ymas; i < 2*m; i++)
        {
            for (int j = xmas; j > 0; j--)
            {
                cor[j, i, 0] = StartPoz.transform.position.x + xpl;
                cor[j, i, 1] = StartPoz.transform.position.y + ypl;
                xpl--;
            }
            xpl = 0;
            ypl++;
        }
        ypl = 0; xpl = 0;
        //Right-Up
        for (int i = ymas; i > 0; i--)
        {
            for (int j = xmas; j < n; j++)
            {
                cor[j, i, 0] = StartPoz.transform.position.x + xpl;
                cor[j, i, 1] = StartPoz.transform.position.y + ypl;
                xpl++;
            }
            xpl = 0;
            ypl--;
        }ypl = 0; xpl = 0;
        //Create
        for (int i = 0; i < 2*m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (vs[i,j] != 0)
                {
                    if (vs[i, j] == 1)
                    {
                        Instantiate(block_middle, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 2)
                    {
                        Instantiate(block_Left, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 3)
                    {
                        Instantiate(block_Right, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 4)
                    {
                        Instantiate(block_Down, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 5)
                    {
                        Instantiate(block_Up, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 6)
                    {
                        Instantiate(Platform_Left, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 7)
                    {
                        Instantiate(Platform_Middle, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 8)
                    {
                        Instantiate(Platform_Right, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 9)
                    {
                        Instantiate(block_Left_Down, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 10)
                    {
                        Instantiate(block_Left_Up, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 11)
                    {
                        Instantiate(block_Right_Down, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 12)
                    {
                        Instantiate(block_Right_Up, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 13)
                    {
                        Instantiate(block_Left_to_Up1, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 14)
                    {
                        Instantiate(block_Left_to_Up2, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 15)
                    {
                        Instantiate(block_Right_to_Up1, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                    else if (vs[i, j] == 16)
                    {
                        Instantiate(block_Right_to_Up2, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                }
            }
        }
    }
    /*
        block_middle = GameObject.Find("Main/SBlock_M");//1
        block_Left = GameObject.Find("Main/SBlock_L");//2
        block_Right = GameObject.Find("Main/SBlock_R");//3
        block_Down = GameObject.Find("Main/SBlock_D");//4
        block_Up = GameObject.Find("Main/SBlock_M_Up");//5
        Platform_Left = GameObject.Find("Main/Platform_L");//6
        Platform_Middle = GameObject.Find("Main/Platform_M");//7
        Platform_Right = GameObject.Find("Main/Platform_R");//8
        block_Left_Down = GameObject.Find("Main/SBlock_L_D");//9
        block_Left_Up = GameObject.Find("Main/SBlock_L_Up");//10
        block_Right_Down = GameObject.Find("Main/SBlock_R_D");//11
        block_Right_Up = GameObject.Find("Main/SBlock_R_Up");//12
        block_Left_to_Up1 = GameObject.Find("Main/SBlock_LL-Up");//13
        block_Left_to_Up2 = GameObject.Find("Main/SBlock_L-Up");//14
        block_Right_to_Up1 = GameObject.Find("Main/SBlock_R-Up");//15
        block_Right_to_Up2 = GameObject.Find("Main/SBlock_RR-Up");//16 
    */
    void Start()
    {

    }
}
