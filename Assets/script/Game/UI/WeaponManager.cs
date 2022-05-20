using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    Button upgreadbutton;

    // ���̾�
    public int Diamond;

    public int Upgread = 0; // ĳ���� ���� ���� �����ϴ� ������ ��

    // ���� ������
    public int SwordDamage = 5;

    // ��ų ������
    public int NormalDamage = 5;
    public int DashDamage = 25;

    // ĳ���� ���� ������
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
        // ���� ���ݷ� + ��ų ���ݷ� + ���׷��̵�
        NormalCalc = SwordDamage + NormalDamage + Upgread; // �Ϲ� ���� ���
        DashCalc = SwordDamage + DashDamage + Upgread; // �뽬 ���� ���

    }

    public void SwordUpgread()
    {
        if (Diamond < 100)
        {
            Debug.Log("���̾ư� �����մϴ�.");
        }
        else if(Diamond >= 100)
        {
            Diamond -= 100; // ���̾� ����
            SwordDamage += 5; // ���� ���ݷ� �ø���
            DataSave();
        }
    }

    public void DataSave()
    {
        PlayerPrefs.SetInt("SwordDamage", SwordDamage); // exp ������ ����
        PlayerPrefs.SetInt("Diamond", Diamond); // ���̾� ����
    }

    public void DataLoad()
    {
        SwordDamage += PlayerPrefs.GetInt("SwordDamage");
        Diamond = PlayerPrefs.GetInt("Diamond");
    }
}
