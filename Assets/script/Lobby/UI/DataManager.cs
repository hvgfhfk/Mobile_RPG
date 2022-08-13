using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    [SerializeField]
    private Player playerCurrent;
    [SerializeField]
    private UI uiCurrent;
    [SerializeField]
    private Slider expSlider;
    [SerializeField]
    private Text diamond;
    [SerializeField]
    private Text exp;
    [SerializeField]
    private Text level;
    [SerializeField]
    private Text upgradeCount;
    [SerializeField]
    private Text defensiveCount;

    private void Awake()
    {
        diamond = GameObject.Find("DiamondCount").GetComponent<Text>();
        exp = GameObject.Find("TextExp").GetComponent<Text>();
        level = GameObject.Find("TextLevel").GetComponent<Text>();

        //  LoadData();
        InvokeRepeating("LoadData", 0.1f, 0.1f);
    }

    void LoadData()
    {
        diamond.text = PlayerPrefs.GetInt("Diamond").ToString();
        exp.text = PlayerPrefs.GetInt("Exp").ToString() + " / 100";
        level.text = PlayerPrefs.GetInt("Level").ToString() + " Lv";
        expSlider.value = PlayerPrefs.GetInt("Exp");
       // playerCurrent.startingHealth = PlayerPrefs.GetInt("StartingHealth");
        upgradeCount.text = "강화 횟수 : " + PlayerPrefs.GetInt("SwordUpgradeCount").ToString();
        defensiveCount.text = "강화 횟수 : " + PlayerPrefs.GetInt("DefensiveCount").ToString();
    }
}
