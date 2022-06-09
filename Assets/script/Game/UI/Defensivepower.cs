using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Defensivepower : MonoBehaviour
{
    [SerializeField]
    Player playerCurrent;

    [SerializeField]
    private UI uiCurrent;

    public GameObject Shortage;

    //public int upgradeCount;
    //public int upgradeDefensive;

    private void Awake()
    {
        uiCurrent.upgradeDefensiveCount = PlayerPrefs.GetInt("DefensiveCount");
       // playerCurrent.startingHealth += uiCurrent.upgradeDefensive;
        DataAutoLoad();
    }

    public void UpgradeDefnsivePower()
    {
        if(uiCurrent.Diamond < 100)
        {
            Shortage.SetActive(true);
            UIFade.instance.StartCoroutine("FadeIn");
        }
        else if(uiCurrent.Diamond >= 100)
        {
            Debug.Log(playerCurrent.startingHealth);
            uiCurrent.Diamond -= 100;
            uiCurrent.upgradeDefensive += 5;
            uiCurrent.upgradeDefensiveCount++;
            //playerCurrent.startingHealth += uiCurrent.upgradeDefensive;
            DataAutoSave();
        }
    }

    public void DataAutoLoad()
    {
        uiCurrent.Diamond = PlayerPrefs.GetInt("Diamond");
        uiCurrent.upgradeDefensive = PlayerPrefs.GetInt("Defensive");
    }

    public void DataAutoSave()
    {
        PlayerPrefs.SetInt("Diamond", uiCurrent.Diamond);
        PlayerPrefs.SetInt("DefensiveCount", uiCurrent.upgradeDefensiveCount);
        PlayerPrefs.SetInt("upgradeDefensive", playerCurrent.startingHealth + uiCurrent.upgradeDefensive);
        PlayerPrefs.SetInt("Defensive", uiCurrent.upgradeDefensive);
    }
    
}
