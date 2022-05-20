using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    Button upgreadbutton;

    // 다이아
    public int Diamond;

    public int Upgread = 0; // 캐릭터 레벨 업시 증가하는 데미지 량

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
    }

    public void DamageCalc()
    {
        DataLoad();
        // 무기 공격력 + 스킬 공격력 + 업그레이드
        NormalCalc = SwordDamage + NormalDamage + Upgread; // 일반 공격 계산
        DashCalc = SwordDamage + DashDamage + Upgread; // 대쉬 공격 계산

    }

    public void SwordUpgread()
    {
        if (Diamond < 100)
        {
            Debug.Log("다이아가 부족합니다.");
        }
        else if(Diamond >= 100)
        {
            Diamond -= 100; // 다이아 차감
            SwordDamage += 5; // 무기 공격력 올리기
            DataSave();
        }
    }

    public void DataSave()
    {
        PlayerPrefs.SetInt("SwordDamage", SwordDamage); // exp 데이터 저장
        PlayerPrefs.SetInt("Diamond", Diamond); // 다이아 저장
    }

    public void DataLoad()
    {
        SwordDamage += PlayerPrefs.GetInt("SwordDamage");
        Diamond = PlayerPrefs.GetInt("Diamond");
    }
}
