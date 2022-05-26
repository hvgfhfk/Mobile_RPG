using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    Button upgreadbutton;
    public GameObject Shortage;

    // 다이아
    public int Diamond;
    // 업그레이드 카운트
    public int UpgradeCount;

    public int Upgrade; // 캐릭터 레벨 업시 증가하는 데미지 량

    // 무기 데미지
    public int SwordDamage = 5;

    // 스킬 데미지
    public int NormalDamage = 5;
    public int DashDamage = 25;

    // 캐릭터 공격 데미지
    public int NormalCalc = 0;
    public int DashCalc = 0;

    private void Awake()
    {
        WeaponManager.instance = this;
        upgreadbutton = GetComponent<Button>();
        DamageCalc();
        DataAutoLoad();
    }

    public void DamageCalc()
    {
        DataAutoLoad();
        // 무기 공격력 + 스킬 공격력 + 업그레이드
        // 50 = 45 + 5 + 0
        NormalCalc = SwordDamage + NormalDamage + Upgrade; // 일반 공격 계산
        DashCalc = SwordDamage + DashDamage + Upgrade; // 대쉬 공격 계산

    }

    public void UpgradeData(int UpgradeLv)
    { // 레벨업시 증가할 공격력 량
        Upgrade += UpgradeLv;
        DataAutoSave();
    }

    public void SwordUpgread()
    {
        if (Diamond < 100)
        {
            Shortage.SetActive(true);
            UIFade.instance.StartCoroutine("FadeIn");
        }
        else if(Diamond >= 100)
        {
            Diamond -= 100; // 다이아 차감
            SwordDamage += 5; // 무기 공격력 올리기
            UpgradeCount++;
            DataAutoSave();
        }
      //  Shortage.SetActive(false);
    }

    public void DataAutoLoad()
    {
        Diamond = PlayerPrefs.GetInt("Diamond");
        SwordDamage = PlayerPrefs.GetInt("SwordDamage");
        Upgrade = PlayerPrefs.GetInt("Upgrade");
    }

    public void DataAutoSave()
    {
        PlayerPrefs.SetInt("Diamond", Diamond);
        PlayerPrefs.SetInt("SwordDamage", SwordDamage);
        PlayerPrefs.SetInt("Upgrade", Upgrade);
        PlayerPrefs.SetInt("UpgradeCount", UpgradeCount);
    }
}
