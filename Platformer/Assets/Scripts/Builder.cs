using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Builder : MonoBehaviour
{
    [SerializeField]
    public GameObject point;
    [HideInInspector]
    public int difficulty = 1;
    [SerializeField]
    int level = 1;
    [SerializeField]
    public int n = 40;
    [SerializeField]
    public int m = 10;
    [SerializeField]
    public int xmas = 0;
    [SerializeField]
    public int ymas = 0;
    public float xpl = 0;
    public float ypl = 0;
    #region GameObjects(var)
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
    private GameObject Platform_3;
    private GameObject block_Left_to_Up1;
    private GameObject block_Left_to_Up2;
    private GameObject block_Right_to_Up1;
    private GameObject block_Right_to_Up2;
    #endregion
    void LevelvsSummer()
    {
        block_middle = GameObject.Find("Main/SBlock_M");//1
        block_Left = GameObject.Find("Main/SBlock_L");//2
        block_Right = GameObject.Find("Main/SBlock_R");//3
        block_Down = GameObject.Find("Main/SBlock_D");//4
        block_Up = GameObject.Find("Main/SBlock_M_Up");//5
        Platform_3 = GameObject.Find("Main/Platform_L");//6
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
        n = n * 2;
        switch (level)
        {
            case 1:
                LevelvsSummer();
                break;
            default:
                LevelvsSummer();
                break;
        }

        int[,] vs = new int[n + 2, (m * 2) + 2]; //Create array
        float[,,] cor = new float[n, m * 2, 2];
        #region Denisov Kode
        System.Random rand = new System.Random(); // Randomization of random numbers generator

        for (int i = 0; i < n + 2; i++)
            for (int j = 0; j < 2 * m + 2; j++)
                vs[i, j] = 0;

        int y_p_ugla = 2;
        int x_p_ugla = m - 1;

        for (int i = y_p_ugla; i < y_p_ugla + 7; i++)
            for (int j = x_p_ugla; j < x_p_ugla + 4; j++)
                vs[i, j] = 1; // First ground plate 4x7

        vs[7, m - 2] = 100; // Counting from
        y_p_ugla += 6; // now it's right corner of first block of ground
        int x = x_p_ugla;
        int y = y_p_ugla;
        int up, down;
        int hmax, wmax; // renaming and new values

        while (y <= n - 4) // function of random grounding
        {
            up = Math.Min(x - 3, 12);
            down = Math.Min(2 * m - x - 2, 12);
            int r_up_down, r_range, r_h, r_w;
            int b_up_down;
            b_up_down = rand.Next() % 2;
            if (b_up_down == 1)
                r_up_down = rand.Next() % Math.Min(5, up + 1);
            else
                r_up_down = -1 * (rand.Next() % Math.Min(5, down + 1));
            int range = Math.Min(5, n - y);
            r_range = rand.Next() % (range + 1);
            x -= r_up_down;
            y += r_range + 1;
            hmax = Math.Min(6, 2 * m - x - 2);
            wmax = Math.Min(12, n - y);
            if (wmax >= 4 && hmax >= 3)
            {
                r_h = rand.Next() % (hmax - 2) + 3;
                r_w = rand.Next() % (wmax - 3) + 4;
                for (int i = y; i < y + r_w; i++)
                    for (int j = x; j < x + r_h; j++)
                        vs[i, j] = 1;
                y += r_w;
            }
            else
                continue;
        }

        for (int i = 0; i < n + 2; i++) //На всякий случай обнулил границы
        {
            vs[i, 0] = 0;
            vs[i, 2 * m + 1] = 0;
        }
        for (int i = 0; i < 2 * m + 2; i++)
        {
            vs[0, i] = 0;
            vs[n + 1, i] = 0;
        }

            #endregion
            //Create symbols
            for (int i = 1; i < n - 1; i++)
        {
            for (int j = 1; j < (2 * m) - 1; j++)
            {
                if (vs[i, j] == 100)
                {
                    ymas = j - 1;
                    xmas = i - 1;
                    vs[i, j] = 0;
                }
            }
        }
        for (int i = 1; i < n - 1; i++)
        {
            for (int j = 1; j < (2 * m) - 1; j++)
            {
                if (vs[i, j] == 20)
                {
                    if (vs[i, j] != 0)
                    {
                        vs[i, j] = 6;
                    }
                }
                else if (vs[i, j] == 1)
                {
                    if (vs[i - 1, j] == 0)
                    {
                        if (vs[i, j - 1] == 0)
                        {
                            vs[i, j] = 10;
                        }
                        else if (vs[i, j + 1] == 0)
                        {
                            vs[i, j] = 9;
                        }
                        else
                        {
                            vs[i, j] = 2;
                        }
                    }
                    else
                    {
                        if (vs[i, j + 1] == 0)
                        {
                            if (vs[i + 1, j] == 0)
                            {
                                vs[i, j] = 11;
                            }
                            else if (vs[i, j] != 9)
                            {
                                vs[i, j] = 4;
                            }
                        }
                        else if (vs[i + 1, j] == 0)
                        {
                            if (vs[i, j - 1] == 0)
                            {
                                vs[i, j] = 12;
                            }
                            else
                            {
                                vs[i, j] = 3;
                            }
                        }
                        else if (vs[i, j - 1] == 0)
                        {
                            if (vs[i, j] != 10 && vs[i, j] != 12)
                            {
                                vs[i, j] = 5;
                            }
                        }
                        else
                        {
                            vs[i, j] = 1;
                        }
                    }
                }
            }
        }
        cor[xmas, ymas, 0] = StartPoz.transform.position.x;
        cor[xmas, ymas, 1] = StartPoz.transform.position.y;
        //Right-Down
        for (int i = xmas; i < n - 1; i++)
        {
            for (int j = ymas; j < 2 * m - 1; j++)
            {
                cor[i, j, 0] = StartPoz.transform.position.x + xpl;
                cor[i, j, 1] = StartPoz.transform.position.y + ypl;
                ypl--;
            }
            ypl = 0;
            xpl++;
        }
        ypl = 0; xpl = 0;
        //Left-Up
        for (int i = xmas; i > 0; i--)
        {
            for (int j = ymas; j > 0; j--)
            {
                cor[i, j, 0] = StartPoz.transform.position.x + xpl;
                cor[i, j, 1] = StartPoz.transform.position.y + ypl;
                ypl++;
            }
            ypl = 0;
            xpl--;
        }
        ypl = 0; xpl = 0;
        //Left-Down
        for (int i = xmas; i > 0; i--)
        {
            for (int j = ymas; j < (2 * m) - 1; j++)
            {
                cor[i, j, 0] = StartPoz.transform.position.x + xpl;
                cor[i, j, 1] = StartPoz.transform.position.y + ypl;
                ypl--;
            }
            ypl = 0;
            xpl--;
        }
        ypl = 0; xpl = 0;
        //Right-Up
        for (int i = xmas; i < n - 1; i++)
        {
            for (int j = ymas; j > 0; j--)
            {
                cor[i, j, 0] = StartPoz.transform.position.x + xpl;
                cor[i, j, 1] = StartPoz.transform.position.y + ypl;
                ypl++;
            }
            ypl = 0;
            xpl--;
        }
        ypl = 0; xpl = 0;
        //Create
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < m * 2 - 1; j++)
            {
                if (vs[i, j] != 0)
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
                    else if (vs[i, j] == 6 && vs[i, j - 1] == 6 && vs[i, j + 1] == 6)
                    {
                        Instantiate(Platform_3, new Vector3(cor[i + 1, j, 0], cor[i + 1, j, 1], 0f), transform.rotation);
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
                    else
                    {
                        Instantiate(point, new Vector3(cor[i, j, 0], cor[i, j, 1], 0f), transform.rotation);
                    }
                }
            }
        }
    }

}