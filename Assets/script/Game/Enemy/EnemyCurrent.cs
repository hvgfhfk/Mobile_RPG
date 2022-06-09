using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCurrent : MonoBehaviour
{ // ?? ???? ????????
    [SerializeField]
    private Player player;

    public string EnemyName; // ���̸�
    public int CurrentHealth; // �� ���� HP
    public float traceDist; // ���� ��Ÿ�
    public float attackDist; // ���� ��Ÿ�
    public int AttackDamage; // ���� ������
    public int StartingHealth; // ���� hp
    public bool isDead; // ���� ����

    public Animator m_anim;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
