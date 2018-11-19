using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lvlmenubtns : MonoBehaviour {
    [SerializeField]
    public Button[] btns = new Button[16];
    public static bool[] lvlsop = new bool[16];
    [SerializeField]
    public Scene[] scenes = new Scene[16];
    int h = 1;
    Button io;    void Start () {
        lvlsop[0] = true;
        for (int i = 1; i < 16; i++)
        {
            lvlsop[i] = false;
        }
            btns[0].onClick.AddListener(Button1Click);
            btns[1].onClick.AddListener(Button2Click);
            btns[2].onClick.AddListener(Button3Click);
            btns[3].onClick.AddListener(Button4Click);
            btns[4].onClick.AddListener(Button5Click);
            btns[5].onClick.AddListener(Button6Click);
            btns[6].onClick.AddListener(Button7Click);
            btns[7].onClick.AddListener(Button8Click);
            btns[8].onClick.AddListener(Button9Click);
            btns[9].onClick.AddListener(Button10Click);
            btns[10].onClick.AddListener(Button11Click);
            btns[11].onClick.AddListener(Button12Click);
            btns[12].onClick.AddListener(Button13Click);
            btns[13].onClick.AddListener(Button14Click);
            btns[14].onClick.AddListener(Button15Click);
            btns[15].onClick.AddListener(Button16Click);
    }
    private void Update()
    {
        if (lvlsop[h] == true)
        {
            io = btns[h].GetComponent<Button>();
            io.interactable = true;
            h++;
        }
    }
    public void Button1Click() { if (lvlsop[0]) SceneManager.LoadScene(scenes[0].buildIndex);}
    public void Button2Click() { if (lvlsop[1]) SceneManager.LoadScene(scenes[1].buildIndex); }
    public void Button3Click() { if (lvlsop[2]) SceneManager.LoadScene(scenes[2].buildIndex); }
    public void Button4Click() { if (lvlsop[3]) SceneManager.LoadScene(scenes[3].buildIndex); }
    public void Button5Click() { if (lvlsop[4]) SceneManager.LoadScene(scenes[4].buildIndex); }
    public void Button6Click() { if (lvlsop[5]) SceneManager.LoadScene(scenes[5].buildIndex); }
    public void Button7Click() { if (lvlsop[6]) SceneManager.LoadScene(scenes[6].buildIndex); }
    public void Button8Click() { if (lvlsop[7]) SceneManager.LoadScene(scenes[7].buildIndex); }
    public void Button9Click() { if (lvlsop[8]) SceneManager.LoadScene(scenes[8].buildIndex); }
    public void Button10Click() { if (lvlsop[9]) SceneManager.LoadScene(scenes[9].buildIndex); }
    public void Button11Click() { if (lvlsop[10]) SceneManager.LoadScene(scenes[10].buildIndex); }
    public void Button12Click() { if (lvlsop[11]) SceneManager.LoadScene(scenes[11].buildIndex); }
    public void Button13Click() { if (lvlsop[12]) SceneManager.LoadScene(scenes[12].buildIndex); }
    public void Button14Click() { if (lvlsop[13]) SceneManager.LoadScene(scenes[13].buildIndex); }
    public void Button15Click() { if (lvlsop[14]) SceneManager.LoadScene(scenes[14].buildIndex); }
    public void Button16Click() { if (lvlsop[15]) SceneManager.LoadScene(scenes[15].buildIndex); }
}
