using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    [SerializeField]
    private UI uiCurrent;

    public GameObject Shortage;

    private void Awake()
    {
        WeaponManager.instance = this;
        DamageCalc();
        DataAutoLoad();
    }

    public void DamageCalc()
    {
        DataAutoLoad();
        // 데미지 계산
        uiCurrent.NormalCalc = uiCurrent.SwordDamage + uiCurrent.NormalDamage + uiCurrent.LevelUpDamageUpgradeCount;
        uiCurrent.DashCalc = uiCurrent.SwordDamage + uiCurrent.DashDamage + uiCurrent.LevelUpDamageUpgradeCount;

    }

    public void UpgradeData(int UpgradeLv)
    { // 레벨업
        uiCurrent.LevelUpDamageUpgradeCount += UpgradeLv;
        DataAutoSave();
    }

    public void SwordUpgread()
    {
        if (uiCurrent.Diamond < 100)
        {
            Shortage.SetActive(true);
            UIFade.instance.StartCoroutine("FadeIn");
        }
        else if(uiCurrent.Diamond >= 100)
        {
            uiCurrent.Diamond -= 100; // 다이아 삭제
            uiCurrent.SwordDamage += 5; // 공격력 증가
            uiCurrent.SwordUpgradeCount++;
            DataAutoSave();
        }
    }

    public void DataAutoLoad()
    {
        uiCurrent.Diamond = PlayerPrefs.GetInt("Diamond");
        uiCurrent.SwordDamage = PlayerPrefs.GetInt("SwordDamage");
        uiCurrent.LevelUpDamageUpgradeCount = PlayerPrefs.GetInt("LevelUpDamageUpgradeCount");
        uiCurrent.SwordUpgradeCount = PlayerPrefs.GetInt("SwordUpgradeCount");
    }

    public void DataAutoSave()
    {
        PlayerPrefs.SetInt("Diamond", uiCurrent.Diamond);
        PlayerPrefs.SetInt("SwordDamage", uiCurrent.SwordDamage);
        PlayerPrefs.SetInt("LevelUpDamageUpgradeCount", uiCurrent.LevelUpDamageUpgradeCount);
        PlayerPrefs.SetInt("SwordUpgradeCount", uiCurrent.SwordUpgradeCount);
    }
}
