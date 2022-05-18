using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;

public class GameManager : MonoBehaviour
{
    public int Exp = 0;
    public float MaxExp = 100.0f;
    public int Lv;

    public static GameManager instance;

    private void Awake()
    {
        GameManager.instance = this;
        dataload();
    }

    void dataload()
    {
        if(PlayerPrefs.HasKey("Level"))
        {
            Exp = PlayerPrefs.GetInt("Exp"); // 경험치 데이터 가져오기
            Lv = PlayerPrefs.GetInt("Level"); // 레벨 데이터 가져오기
        }
    }
}
