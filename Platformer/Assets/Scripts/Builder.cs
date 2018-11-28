using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
    #region Constants
    [SerializeField]
    private GameObject character;
    [SerializeField]
    private GameObject debug;
    [SerializeField]
    private string level = "Summer";//Какой уровень по ландшафту
    [SerializeField]
    private int h = 10;//Высота уровня
    [SerializeField]
    private int a = 20;//Длина уровня
    [SerializeField]
    private int o = 70;//Процент земли на воде
    [SerializeField]
    private int n = 70;//Процент загруженности платформами
    private int difficult = 1;//Сложность уровня
    [SerializeField]
    private int secrets = 3;//Количество секретов
    [SerializeField]
    private int coins = 10;//Количество монет
    public static int moneys = 100;//Суммарная стоимость монет
    public static float perx = 0;
    public static float pery = 0;
    #endregion
    #region Blocks
    private GameObject Finish;
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
    #region Enemies
    private GameObject FlyingSkelet;
    private GameObject Spider;
    #endregion
    void LevelvsSummer()
    {
        Platform_3 = Resources.Load("SPlatform3") as GameObject;
        block_Down = Resources.Load("Sblock_D") as GameObject;
        block_Left = Resources.Load("Sblock_L") as GameObject;
        block_Left_Down = Resources.Load("Sblock_L_D") as GameObject;
        block_Left_Up = Resources.Load("Sblock_L_Up") as GameObject;
        block_Left_to_Up1 = Resources.Load("Sblock_LL-Up") as GameObject;
        block_Left_to_Up2 = Resources.Load("Sblock_L-Up") as GameObject;
        block_middle = Resources.Load("Sblock_M") as GameObject;
        block_Right = Resources.Load("Sblock_R") as GameObject;
        block_Right_Down = Resources.Load("Sblock_R_D") as GameObject;
        block_Right_Up = Resources.Load("Sblock_R_Up") as GameObject;
        block_Right_to_Up1 = Resources.Load("Sblock_RR-Up") as GameObject;
        block_Right_to_Up2 = Resources.Load("Sblock_R-Up") as GameObject;
        block_Up = Resources.Load("Sblock_M_Up") as GameObject;
    }
    void Standart()
    {
        Finish = Resources.Load("Finish") as GameObject;
        Spider = Resources.Load("Spider") as GameObject;
        FlyingSkelet = Resources.Load("Horn") as GameObject;
    }
    private void Awake()
    {
        Standart();
        System.Random rand = new System.Random();
        difficult = Global.difficulty;
        switch (level)
        {
            case "Summer":
                LevelvsSummer();
                break;
            default:
                LevelvsSummer();
                break;
        }
        float xpl = 0, ypl = 0;
        int persx = 0, persy = 0;
        string[,] greed = new string[a + 2, h + 2];
        float[,,] cor = new float[a, h, 2];
        for (int i = 0; i < a; i++)
        {
            for (int j = h - 1; j >= 0; j--)
            {
                cor[i, j, 0] = xpl;
                cor[i, j, 1] = ypl;
                ypl++;
            }
            ypl = 0;
            xpl++;
        }//create positions
        #region DenisovCode
        //Code
        for (int i = 0; i < a + 2; i++)
            for (int j = 0; j < h + 2; j++)
                greed[i, j] = "null"; //fill "null"
        for (int i = 1; i <= 3; i++)
            for (int j = h - 1; j <= h; j++)
                greed[i, j] = "Solid"; // 3x2 platform
        greed[2, h - 4] = "Character";
        int[] ar = new int[a + 2];
        for (int i = 0; i < a + 2; i++)
            ar[i] = 0;
        ar[1] = 1;
        ar[2] = 1;
        ar[3] = 1;
        int n_zem = a * o * 70 / 100;
        n_zem -= 3;
        int s = 4;
        int range;
        while (s <= a && n_zem >= 0)
        {
            int l = 1000;
            while (s + l > a)
                l = rand.Next(2, 12);
            for (int i = s; i <= Math.Min(s + l, a); i++)
                ar[i] = 1;
            s += l;
            n_zem -= l;
            range = rand.Next(0, 8);
            s += range;
        }
        s = 4;
        int per, r_h, r_w;
        while (s <= a)
            if (ar[s] == 1)
            {
                int begin = s, end = s;
                while (ar[end] == 1)
                    end++;
                end--;
                per = begin;
                while (per <= end)
                {
                    r_h = rand.Next(1, 6);
                    if (end - per < 2)
                    {
                        for (int i = per; i <= end; i++)
                            ar[i] = ar[per - 1];
                        break;
                    }
                    r_w = rand.Next(2, Math.Min(end - per, 8));
                    for (int i = per; i < per + r_w; i++)
                        ar[per] = r_h;
                    per += r_w;
                }
            }
            else
                s++;
        for (int i = 4; i <= a; i++)
        {
            if (ar[i] != ar[i - 1] && ar[i] != ar[i + 1] && ar[i] != 0)
                ar[i] = ar[i - 1];
            if (ar[i] == 1)
                ar[i]++;
        }
        for (int i = 4; i <= a; i++)
            for (int j = h; j > h - ar[i]; j--)
                greed[i, j] = "Solid";
        for (int i = a; i >= 4; i--)
            if (ar[i] != 0)
            {
                greed[i, ar[i] + 2] = "Finish";
                break;
            }
        #endregion
        //Symbols
        int finx = 0, finy = 0;
        for (int i = 1; i < a; i++)
        {
            for (int j = 1; j < h; j++)
            {
                if (greed[i, j] == "Character")
                {
                    persx = i - 1;
                    persy = j - 1;
                    greed[i, j] = "null";
                } else if (greed[i, j] == "Finish")
                {
                    finx = i - 1;
                    finy = j - 1;
                    greed[i, j] = "null";
                }
            }
        }
        for (int i = 1; i <= a; i++)
        {
            for (int j = 1; j <= h; j++)
            {
                if (greed[i, j] == "Platform")
                {
                    greed[i, j] = "Platform3";
                }
                else if (greed[i, j] == "Solid")
                {
                    if (greed[i - 1, j] == "null")
                    {
                        if (greed[i, j + 1] != "null" && greed[i, j - 1] != "null")
                        {
                            greed[i, j] = "block_Left";
                        }
                        else if (greed[i, j + 1] == "null" && greed[i, j - 1] != "null")
                        {
                            greed[i, j] = "block_Left_Down";
                        }
                        else
                        {
                            greed[i, j] = "block_Left_Up";
                        }
                    }
                    else if (greed[i + 1, j] == "null")
                    {
                        if (greed[i, j + 1] != "null" && greed[i, j - 1] != "null")
                        {
                            greed[i, j] = "block_Right";
                        }
                        else if (greed[i, j + 1] == "null" && greed[i, j - 1] != "null")
                        {
                            greed[i, j] = "block_Right_Down";
                        }
                        else
                        {
                            greed[i, j] = "block_Right_Up";
                        }
                    }
                    else if (greed[i, j + 1] == "null")
                    {
                        greed[i, j] = "block_Down";
                    }
                    else if (greed[i, j - 1] == "null")
                    {
                        if (greed[i + 1, j - 1] == "null" && greed[i - 1, j - 1] != "null")
                        {
                            greed[i, j] = "block_Right_to_Up1";
                        }
                        else if (greed[i + 1, j - 1] != "null" && greed[i - 1, j - 1] == "null")
                        {
                            greed[i, j] = "block_Left_to_Up1";
                        }
                        else
                        {
                            greed[i, j] = "block_Up";
                        }
                    }
                    else if (greed[i - 1, j - 1] == "null")
                    {
                        greed[i, j] = "block_Left_to_Up2";
                    }
                    else if (greed[i + 1, j - 1] == "null")
                    {
                        greed[i, j] = "block_Right_to_Up2";
                    }
                    else
                    {
                        greed[i, j] = "block_middle";
                    }
                }
            }
        }
        //Creating
        for (int i = 1; i <= a; i++)
        {
            for (int j = 1; j <= h; j++)
            {
                if (greed[i, j] == "block_Right_Up")
                {
                    Instantiate(FlyingSkelet, new Vector3(cor[i - 1, j - 1, 0]-0.5f, cor[i - 1, j - 1, 1]+1.5f, 0), transform.rotation);
                }
            }
        }
                perx = cor[persx, persy, 0]; pery = cor[persx, persy, 0];
        character.transform.position = new Vector3(perx, perx, -1);
        //Finish.transform.position = new Vector3(finx, finy, -1);
        Instantiate(Finish, new Vector3(finx, finy-1, 0), transform.rotation);
        for (int i = 1; i <= a; i++)
        {
            for (int j = 1; j <= h; j++)
            {
                if (greed[i, j] != "null")
                {
                    if (greed[i, j] == "block_middle")
                    {
                        Instantiate(block_middle, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "block_Left")
                    {
                        Instantiate(block_Left, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "block_Left_Down")
                    {
                        Instantiate(block_Left_Down, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "block_Left_Up")
                    {
                        Instantiate(block_Left_Up, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "block_Right")
                    {
                        Instantiate(block_Right, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "block_Right_Down")
                    {
                        Instantiate(block_Right_Down, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "block_Right_Up")
                    {
                        Instantiate(block_Right_Up, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "block_Down")
                    {
                        Instantiate(block_Down, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "block_Up")
                    {
                        Instantiate(block_Up, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "Platform_3")
                    {
                        Instantiate(Platform_3, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "block_Left_to_Up1")
                    {
                        Instantiate(block_Left_to_Up1, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "block_Left_to_Up2")
                    {
                        Instantiate(block_Left_to_Up2, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "block_Right_to_Up1")
                    {
                        Instantiate(block_Right_to_Up1, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                    else if (greed[i, j] == "block_Right_to_Up2")
                    {
                        Instantiate(block_Right_to_Up2, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    }
                }
                else
                {
                    /*Instantiate(debug, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 1], 0), transform.rotation);
                    TextMesh text = debug.GetComponent<TextMesh>();
                    text.text = greed[i, j] + " KO\nx-" + cor[i - 1, j - 1, 0] + " y-" + cor[i - 1, j - 1, 1] + "\n" + i + " " + j;*/
                }
            }
        }
    }
}