using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator p_anim; // �ִϸ��̼�
    public Effect effect; // ����Ʈ
    public float LastAttackTime; // ������ �ð�
    public float LastDashTime; // ��ų(�뽬) ����� �ð�
    public bool attacking = false; // ���� ����
    public bool dashing = false; // ��ų ��� ����
    public GameObject NormalHit; // �Ϲ� ���� ����Ʈ
    public GameObject dashingHit; // ��ų ���� ����Ʈ
    public int startingHealth; // �÷��̾� ���� ü��
    public bool isdead = false; // ���� Ȯ��
    public bool damaged; // ������ �Ծ����� Ȯ�� (player)
}
