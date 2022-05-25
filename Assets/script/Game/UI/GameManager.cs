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
        MonsterMaxDead = Random.Range(0, 10);
        DataLoad();
        StartCoroutine(DataLoadTime());
    }

    public void GetDiamond(int newDia)
    {
        Diamond += newDia;
        DataSave();
    }

    public void GetExp(int GetExp)
    {
        if(Exp <= MaxExp)
        {
            Exp += GetExp;
            if(Exp >= MaxExp)
            {
                Exp = 0; // 경험치 초기화
                WeaponManager.instance.Upgread += 1;
                WeaponManager.instance.DamageCalc();
                ++Lv; // 레벨업
            }
            DataSave();
        }
    }

    void DataSave()
    {
        PlayerPrefs.SetInt("Exp", Exp); // exp 데이터 저장
        PlayerPrefs.SetInt("Level", Lv); // 레벨 데이터 저장
        PlayerPrefs.SetInt("Diamond", Diamond); // 다이아 저장
    }

    void DataLoad()
    { // 게임 데이터 로드
        if(PlayerPrefs.HasKey("Level"))
        {
            Exp = PlayerPrefs.GetInt("Exp"); // 경험치 데이터 가져오기
            Lv = PlayerPrefs.GetInt("Level"); // 레벨 데이터 가져오기
            Diamond = PlayerPrefs.GetInt("Diamond"); // 다이아 데이터 불러오기
        }
    }

    public void MoveLobby()
    {
        SceneManager.LoadSceneAsync("Lobby");
    }

    public void MaxMonsterDead()
    {
        Invoke("MoveLobby", 10);
    }

    IEnumerator DataLoadTime()
    {
        yield return new WaitForSeconds(0.1f);

        DataLoad();
    }
}
