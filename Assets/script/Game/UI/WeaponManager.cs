using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    public static WeaponManager instance;

    Button upgreadbutton;
    public GameObject Shortage;

    // ���׷��̵� ī��Ʈ
    [SerializeField]
    private int UpgradeCount;
    [SerializeField]
    private int Upgrade; // ĳ���� ���� ���� �����ϴ� ������ ��
    // ���� ������
    [SerializeField]
    private int SwordDamage = 5;
    // ��ų ������
    [SerializeField]
    private int NormalDamage = 5;
    [SerializeField]
    private int DashDamage = 25;

    // ���̾�
    public int Diamond;
    // ĳ���� ���� ������
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
        // ���� ���ݷ� + ��ų ���ݷ� + ���׷��̵�
        // 50 = 45 + 5 + 0
        NormalCalc = SwordDamage + NormalDamage + Upgrade; // �Ϲ� ���� ���
        DashCalc = SwordDamage + DashDamage + Upgrade; // �뽬 ���� ���

    }

    public void UpgradeData(int UpgradeLv)
    { // �������� ������ ���ݷ� ��
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
            Diamond -= 100; // ���̾� ����
            SwordDamage += 5; // ���� ���ݷ� �ø���
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
        UpgradeCount = PlayerPrefs.GetInt("UpgradeCount");
    }

    public void DataAutoSave()
    {
        PlayerPrefs.SetInt("Diamond", Diamond);
        PlayerPrefs.SetInt("SwordDamage", SwordDamage);
        PlayerPrefs.SetInt("Upgrade", Upgrade);
        PlayerPrefs.SetInt("UpgradeCount", UpgradeCount);
    }
}
