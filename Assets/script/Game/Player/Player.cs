using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator p_anim; // 애니메이션
    public Effect effect; // 이펙트
    public float LastAttackTime; // 공격한 시간
    public float LastDashTime; // 스킬(대쉬) 사용한 시간
    public bool attacking = false; // 공격 여부
    public bool dashing = false; // 스킬 사용 여부
    public GameObject NormalHit; // 일반 공격 이펙트
    public GameObject dashingHit; // 스킬 공격 이펙트
    public int startingHealth; // 플레이어 시작 체력
    public bool isdead = false; // 죽음 확인
    public bool damaged; // 데미지 입었는지 확인 (player)
}
