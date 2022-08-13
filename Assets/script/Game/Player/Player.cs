using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator anim;
    public Effect effect;
    public float lastAttackTime; // 마지막 공격 시간
    public float lastDashTime; // 마지막 스킬 시간
    public bool isAttackStatus = false; // 공격 여부
    public bool isDashStatus = false; // 스킬 사용 여부
    public GameObject normalHit; // 일반공격 이펙트
    public GameObject dashingHit; // 스킬 공격 이펙트
    public bool isDead = false; // 죽음 여부
    public bool damaged; // 데미지를 받았는지 확인(player)
    public int startingHealth;

}
