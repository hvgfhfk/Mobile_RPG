using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int Exp = 0;
    [SerializeField]
    private float MaxExp = 100.0f;
    [SerializeField]
    private int Diamond = 0;
    [SerializeField]
    private int Lv = 1;

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
                Exp = 0; // ����ġ �ʱ�ȭ
                WeaponManager.instance.UpgradeData(1);
                WeaponManager.instance.DamageCalc();
                ++Lv; // ������
            }
            DataAutoSave();
        }
    }

    public void MoveLobby()
    {
        SceneManager.LoadSceneAsync("Lobby");
    }

    public void DataAutoLoad() // ������ �ε�
    {
        Diamond = WeaponManager.instance.Diamond;

        Lv = PlayerPrefs.GetInt("Level"); // ���� ������ ��������
        Exp = PlayerPrefs.GetInt("Exp");
    }
    public void DataAutoSave() // ������ ���̺�
    {
        PlayerPrefs.SetInt("Exp", Exp);
        PlayerPrefs.SetInt("Level", Lv);
        PlayerPrefs.SetInt("Diamond", Diamond);
    }
}