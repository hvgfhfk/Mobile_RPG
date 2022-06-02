using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UI uiCurrent;

    public static GameManager instance;

    private void Awake()
    {
        GameManager.instance = this;
        uiCurrent.MonsterMaxDead = Random.Range(5, 15);
        DataAutoLoad();
    }

    public void GetDiamond(int newDia)
    {
        uiCurrent.Diamond += newDia;
        DataAutoSave();
    }

    public void GetExp(int GetExp)
    {
        if (uiCurrent.Exp <= uiCurrent.MaxExp)
        {
            uiCurrent.Exp += GetExp;
            if (uiCurrent.Exp >= uiCurrent.MaxExp)
            {
                uiCurrent.Exp = 0; // 경험치 초기화
                WeaponManager.instance.UpgradeData(1);
                WeaponManager.instance.DamageCalc();
                ++uiCurrent.Lv; // 레벨 증가
            }
            DataAutoSave();
        }
    }

    public void MoveLobby()
    {
        SceneManager.LoadSceneAsync("Lobby");
    }

    public void DataAutoLoad() // 데이터 불러오기
    {
        //uiCurrent.Diamond = WeaponManager.instance.Diamond;

        uiCurrent.Lv = PlayerPrefs.GetInt("Level");
        uiCurrent.Exp = PlayerPrefs.GetInt("Exp");
    }
    public void DataAutoSave() // 데이터 세이브
    {
        PlayerPrefs.SetInt("Exp", uiCurrent.Exp);
        PlayerPrefs.SetInt("Level", uiCurrent.Lv);
        PlayerPrefs.SetInt("Diamond", uiCurrent.Diamond);
    }
}