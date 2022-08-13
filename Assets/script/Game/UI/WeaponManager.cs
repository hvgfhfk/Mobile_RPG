using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    [SerializeField]
    private UI uiCurrent;

    // 다이아 부족 메세지
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
        uiCurrent.normalCalc = uiCurrent.swordDamage + uiCurrent.normalDamage + uiCurrent.levelUpDamageUpgradeCount;
        uiCurrent.dashCalc = uiCurrent.swordDamage + uiCurrent.dashDamage + uiCurrent.levelUpDamageUpgradeCount;

    }

    public void UpgradeData(int upgradeLv)
    { // 레벨업
        uiCurrent.levelUpDamageUpgradeCount += upgradeLv;
        DataAutoSave();
    }

    public void SwordUpgread()
    {
        if (uiCurrent.diamond < 100)
        {
            Shortage.SetActive(true);
            UIFade.instance.StartCoroutine("FadeIn");
        }
        else if(uiCurrent.diamond >= 100)
        {
            UseDiamond();
            DataAutoSave();
        }
    }

    private void UseDiamond()
    {
        uiCurrent.diamond -= 100; // 다이아 사용
        UpgradeSwordPower();
    }

    private void UpgradeSwordPower()
    {
        uiCurrent.swordDamage += 5; // 공격력 증가
        uiCurrent.swordUpgradeCount++;
    }

    public void DataAutoLoad()
    {
        uiCurrent.diamond = PlayerPrefs.GetInt("Diamond");
        uiCurrent.swordDamage = PlayerPrefs.GetInt("SwordDamage");
        uiCurrent.levelUpDamageUpgradeCount = PlayerPrefs.GetInt("LevelUpDamageUpgradeCount");
        uiCurrent.swordUpgradeCount = PlayerPrefs.GetInt("SwordUpgradeCount");
    }

    public void DataAutoSave()
    {
        PlayerPrefs.SetInt("Diamond", uiCurrent.diamond);
        PlayerPrefs.SetInt("SwordDamage", uiCurrent.swordDamage);
        PlayerPrefs.SetInt("LevelUpDamageUpgradeCount", uiCurrent.levelUpDamageUpgradeCount);
        PlayerPrefs.SetInt("SwordUpgradeCount", uiCurrent.swordUpgradeCount);
    }
}