using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private UI uiCurrent;
    [SerializeField]
    private Player playerCurrent;

    public static GameManager instance;

    private void Awake()
    {
        GameManager.instance = this;
        DataAutoLoad();
    }

    public void GetDiamond(int newDia)
    {
        uiCurrent.diamond += newDia;
        DataAutoSave();
    }

    public void GetExp(int getExp)
    {
        if (uiCurrent.exp <= uiCurrent.maxExp)
        {
            uiCurrent.exp += getExp;
            if (uiCurrent.exp >= uiCurrent.maxExp)
            {
                PlayerLevelUp();
            }
            DataAutoSave();
        }
    }

    private void PlayerLevelUp()
    {
        uiCurrent.exp = 0;
        ++uiCurrent.lv;
        WeaponManager.instance.UpgradeData(1);
        WeaponManager.instance.DamageCalc();

    }

    public void MoveLobby()
    {
        LoadSceneController.LoadScene("Lobby");
    }

    public void DataAutoLoad() // 데이터 불러오기
    {
        //uiCurrent.Diamond = WeaponManager.instance.Diamond;

        uiCurrent.lv = PlayerPrefs.GetInt("Level");
        uiCurrent.exp = PlayerPrefs.GetInt("Exp");
        playerCurrent.startingHealth = PlayerPrefs.GetInt("upgradeDefensive");
    }
    public void DataAutoSave() // 데이터 세이브
    {
        PlayerPrefs.SetInt("Exp", uiCurrent.exp);
        PlayerPrefs.SetInt("Level", uiCurrent.lv);
        PlayerPrefs.SetInt("Diamond", uiCurrent.diamond);
    }
}