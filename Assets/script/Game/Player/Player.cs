using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator p_anim;
    public Effect effect;
    public float LastAttackTime; // 마지막 공격 시간
    public float LastDashTime; // 마지막 스킬 시간
    public bool attacking = false; // 공격 여부
    public bool dashing = false; // 스킬 사용 여부
    public GameObject NormalHit; // 일반공격 이펙트
    public GameObject dashingHit; // 스킬 공격 이펙트
    public bool isdead = false; // 죽음 여부
    public bool damaged; // 데미지를 받았는지 확인(player)
    public int startingHealth;
}
