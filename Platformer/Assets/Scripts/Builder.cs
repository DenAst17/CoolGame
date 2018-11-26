using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Builder : MonoBehaviour
{
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
    [SerializeField]
    private int difficult = 1;//Сложность уровня
    [SerializeField]
    private int hsolid = 20;//Максимальная высота земли
    [SerializeField]
    private int secrets = 3;//Количество секретов
    [SerializeField]
    private int coins = 10;//Количество монет
    public static int moneys = 100;//Суммарная стоимость монет
    #region Blocks
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
    private void Awake()
    {
        switch (level)
        {
            case "Summer":
                LevelvsSummer();
                break;
            default:
                LevelvsSummer();
                break;
        }
        int xpl = 0, ypl = 0,persx = 0,persy = 0;
        string[,] greed = new string[a + 2, h + 2];
        float[,,] cor = new float[a, h, 2];
        for (int i = 0; i < a; i++)
        {
            for (int j = h-1; j >= 0; j--)
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
        for (int i = 0; i < a+2; i++)
        {
            for (int j = 0; j < h+2; j++)
            {
                greed[i, j] = "null";
            }
        }//fill "null"
        greed[8, 3] = "Character";
        for (int i = 4; i < 12; i++)
        {
            for (int j = 4; j >= 8; j++)
            {
                greed[i, j] = "Solid";
            }
        }
        #endregion
        //Symbols
        for (int i = 1; i < a; i++)
        {
            for (int j = 1; j < h; j++)
            {
                if (greed[i,j] == "Character")
                {
                    Debug.Log("Character");
                    persx = i-1;
                    persy = j-1;
                }
            }
        }
        for (int i = 1; i < a; i++)
        {
            for (int j = 1; j < h; j++)
            {
                if (greed[i, j] == "Platform")
                {
                    greed[i, j] = "Platform3";
                }
                else if(greed[i, j] == "Solid")
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
                            greed[i, j] = "block_Left_to_Up1";
                        }
                        else if (greed[i + 1, j - 1] != "null" && greed[i - 1, j - 1] == "null")
                        {
                            greed[i, j] = "block_Right_to_Up1";
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
        character.transform.position = new Vector3(cor[persx,persy,0], cor[persx, persy, 0],-1);
        for (int i = 1; i <= a; i++)
        {
            for (int j = 1; j <= h; j++)
            {
                if (greed[i, j] != "null")
                {
                    if (greed[i, j] == "block_middle")
                    {
                        Instantiate(block_middle, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 0], 0), transform.rotation);
                    }
                }
                else
                {
                    Instantiate(debug, new Vector3(cor[i - 1, j - 1, 0], cor[i - 1, j - 1, 0], 0), transform.rotation);
                    TextMesh text = debug.GetComponent<TextMesh>();
                    text.text = greed[i, j] + " KO\nx-" + Convert.ToString(cor[i - 1, j - 1, 0]) +" y-"+ Convert.ToString(cor[i - 1, j - 1, 0]) + "\n" + Convert.ToString(i) +" "+ Convert.ToString(j);
                }
            }
        }
    }

}