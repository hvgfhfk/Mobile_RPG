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

    // 다이아 부족 메세지
    public GameObject shortage;

    private void Awake()
    {
        uiCurrent.upgradeDefensiveCount = PlayerPrefs.GetInt("DefensiveCount");
        DataAutoLoad();
    }

    public void UpgradeDefensivePower()
    {
        if(uiCurrent.diamond < 100)
        {
            shortage.SetActive(true);
            UIFade.instance.StartCoroutine("FadeIn");
        }
        else if(uiCurrent.diamond >= 100)
        {
            UseDiamond();
            DataAutoSave();
        }
    }

    private void UseDiamond()
    { // 다이아 몬드 사용
        uiCurrent.diamond -= 100;
        UpgradeDefensive();
    }

    private void UpgradeDefensive()
    { // 방어력 업그레이드
        uiCurrent.upgradeDefensive += 5;
        uiCurrent.upgradeDefensiveCount++;
    }

    public void DataAutoLoad()
    {
        uiCurrent.diamond = PlayerPrefs.GetInt("Diamond");
        uiCurrent.upgradeDefensive = PlayerPrefs.GetInt("Defensive");
    }

    public void DataAutoSave()
    {
        PlayerPrefs.SetInt("Diamond", uiCurrent.diamond);
        PlayerPrefs.SetInt("DefensiveCount", uiCurrent.upgradeDefensiveCount);
        PlayerPrefs.SetInt("upgradeDefensive", playerCurrent.startingHealth + uiCurrent.upgradeDefensive);
        PlayerPrefs.SetInt("Defensive", uiCurrent.upgradeDefensive);
    }
    
}
