using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator p_anim;
    public Effect effect;
    public float LastAttackTime; // ������ ���� �ð�
    public float LastDashTime; // ������ ��ų �ð�
    public bool attacking = false; // ���� ����
    public bool dashing = false; // ��ų ��� ����
    public GameObject NormalHit; // �Ϲݰ��� ����Ʈ
    public GameObject dashingHit; // ��ų ���� ����Ʈ
    public bool isdead = false; // ���� ����
    public bool damaged; // �������� �޾Ҵ��� Ȯ��(player)
    public int startingHealth;
}
