using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public int UpgradeCount;  // ���� ���׷��̵� ��
    public int Upgrade; // ������ �� ���׷��̵�
    public int SwordDamage = 5; // ���� ���ݷ�
    public int NormalDamage = 5; // �Ϲ� ���ݷ�
    public int DashDamage = 25; // ��ų ���ݷ�
    public int Diamond; // ���̾� ��� ��
    public int NormalCalc = 0; // �Ϲ� ���ݷ� �� ��
    public int DashCalc = 0; // ��ų ���ݷ� �� ��
    public int Exp = 0; // ����ġ
    public float MaxExp = 100.0f; // �ִ� ����ġ
    public int Lv = 1; // ����
    public int DeadCount = 0; // ���� Ƚ��
    public int MonsterMaxDead; // �ִ� ���� Ƚ��
}
