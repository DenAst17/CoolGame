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
        block_middle = GameObject.Find("Main/SBlock_M");
        block_Left = GameObject.Find("Main/SBlock_L");
        block_Right = GameObject.Find("Main/SBlock_R");
        block_Down = GameObject.Find("Main/SBlock_D");
        block_Up = GameObject.Find("Main/SBlock_M_Up");
        Platform_Left = GameObject.Find("Main/Platform_L");
        Platform_Middle = GameObject.Find("Main/Platform_M");
        Platform_Right = GameObject.Find("Main/Platform_R");
        block_Left_Down = GameObject.Find("Main/SBlock_L_D");
        block_Left_Up = GameObject.Find("Main/SBlock_L_Up");
        block_Right_Down = GameObject.Find("Main/SBlock_R_D");
        block_Right_Up = GameObject.Find("Main/SBlock_R_Up");
        block_Left_to_Up1 = GameObject.Find("Main/SBlock_LL-Up");
        block_Left_to_Up2 = GameObject.Find("Main/SBlock_L-Up");
        block_Right_to_Up1 = GameObject.Find("Main/SBlock_R-Up");
        block_Right_to_Up2 = GameObject.Find("Main/SBlock_RR-Up");
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
    }
    void Start()
    {
        int nowlensth = 0;
        while (nowlensth < levellensth)
        {

        }
    }
}
