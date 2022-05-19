using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public Slider expslider;

    public Text Diamond;
    public Text Exp;
    public Text Level;

    private void Awake()
    {
        Diamond = GameObject.Find("DiamondCount").GetComponent<Text>();
        Exp = GameObject.Find("TextExp").GetComponent<Text>();
        Level = GameObject.Find("TextLevel").GetComponent<Text>();

        LoadData();
    }


    void LoadData()
    {
        Diamond.text = PlayerPrefs.GetInt("Diamond").ToString();
        Exp.text = PlayerPrefs.GetInt("Exp").ToString() + " / 100";
        Level.text = PlayerPrefs.GetInt("Level").ToString() + " Lv";
        expslider.value = PlayerPrefs.GetInt("Exp");
    }
}