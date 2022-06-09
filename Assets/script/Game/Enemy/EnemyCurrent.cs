using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCurrent : MonoBehaviour
{ // �� ���� ��ũ��Ʈ
    [SerializeField]
    private Player player;

    public string EnemyName; // �� �̸�
    public int CurrentHealth; // �� ���� HP
    public float traceDist; // ���� ��Ÿ�
    public float attackDist; // ���� ��Ÿ�
    public int AttackDamage; // �� ���� ������
    public int StartingHealth; // �� ���� HP
    public bool isDead; // �� ���� Ȯ��

    public Animator m_anim; // �ִϸ�����

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
