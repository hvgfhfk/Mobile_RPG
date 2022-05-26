using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Exp = 0;
    public float MaxExp = 100.0f;
    public int Diamond = 0;
    public int Lv = 1;

    public int DeadCount = 0;
    public int MonsterMaxDead;

    public static GameManager instance;

    private void Awake()
    {
        GameManager.instance = this;
        MonsterMaxDead = Random.Range(5, 15);
        DataAutoLoad();
    }

    public void GetDiamond(int newDia)
    {
        Diamond += newDia;
        DataAutoSave();
    }

    public void GetExp(int GetExp)
    {
        if (Exp <= MaxExp)
        {
            Exp += GetExp;
            if (Exp >= MaxExp)
            {
                Exp = 0; // 경험치 초기화
                WeaponManager.instance.UpgradeData(1);
                WeaponManager.instance.DamageCalc();
                ++Lv; // 레벨업
            }
            DataAutoSave();
        }
    }

    public void MoveLobby()
    {
        SceneManager.LoadSceneAsync("Lobby");
    }

    public void DataAutoLoad() // 데이터 로드
    {
        Diamond = WeaponManager.instance.Diamond;

        Lv = PlayerPrefs.GetInt("Level"); // 레벨 데이터 가져오기
        Exp = PlayerPrefs.GetInt("Exp");
    }
    public void DataAutoSave() // 데이터 세이브
    {
        PlayerPrefs.SetInt("Exp", Exp);
        PlayerPrefs.SetInt("Level", Lv);
        PlayerPrefs.SetInt("Diamond", Diamond);
    }
}