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
                Exp = 0; // ����ġ �ʱ�ȭ
                WeaponManager.instance.Upgread += 1;
                WeaponManager.instance.DamageCalc();
                ++Lv; // ������
            }
            DataSave();
        }
    }

    void DataSave()
    {
        PlayerPrefs.SetInt("Exp", Exp); // exp ������ ����
        PlayerPrefs.SetInt("Level", Lv); // ���� ������ ����
        PlayerPrefs.SetInt("Diamond", Diamond); // ���̾� ����
    }

    void DataLoad()
    { // ���� ������ �ε�
        if(PlayerPrefs.HasKey("Level"))
        {
            Exp = PlayerPrefs.GetInt("Exp"); // ����ġ ������ ��������
            Lv = PlayerPrefs.GetInt("Level"); // ���� ������ ��������
            Diamond = PlayerPrefs.GetInt("Diamond"); // ���̾� ������ �ҷ�����
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
