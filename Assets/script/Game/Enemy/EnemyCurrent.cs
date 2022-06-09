using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCurrent : MonoBehaviour
{ // 적 관리 스크립트
    [SerializeField]
    private Player player;

    public string EnemyName; // 적 이름
    public int CurrentHealth; // 적 현재 HP
    public float traceDist; // 추적 사거리
    public float attackDist; // 공격 사거리
    public int AttackDamage; // 적 공격 데미지
    public int StartingHealth; // 적 시작 HP
    public bool isDead; // 적 죽음 확인

    public Animator m_anim; // 애니메이터

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
