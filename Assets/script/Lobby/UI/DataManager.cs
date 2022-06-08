using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private Slider expslider;
    [SerializeField]
    private Text Diamond;
    [SerializeField]
    private Text Exp;
    [SerializeField]
    private Text Level;
    [SerializeField]
    private Text UpgradeCount;

    private void Awake()
    {
        Diamond = GameObject.Find("DiamondCount").GetComponent<Text>();
        Exp = GameObject.Find("TextExp").GetComponent<Text>();
        Level = GameObject.Find("TextLevel").GetComponent<Text>();

        //  LoadData();
        InvokeRepeating("LoadData", 0.1f, 0.1f);
    }

    void LoadData()
    {
        Diamond.text = PlayerPrefs.GetInt("Diamond").ToString();
        Exp.text = PlayerPrefs.GetInt("Exp").ToString() + " / 100";
        Level.text = PlayerPrefs.GetInt("Level").ToString() + " Lv";
        expslider.value = PlayerPrefs.GetInt("Exp");
        UpgradeCount.text = "강화 횟수 : " + PlayerPrefs.GetInt("UpgradeCount").ToString();
    }
}
