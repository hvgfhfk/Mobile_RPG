using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // 플레이어 시작 체력
    public int startingHealth = 100;
    // 현재 체력
    public int currentHealth;
    // 체력 게이지 UI와 연결된 변수
    public Slider healthSlider;
    // 주인공이 데미지 입을 때 화면을 빨갛게 만들기 위한 투명이미지
    public Image damageImage;
    // 주인공이 데미지입을 경우 재생할 오디오
    public AudioClip deathClip;

    // 화면이 변한뒤 투명한 상태로 돌아가는 속도
    public float flashSpeed = 5f;
    // 데미지를 입었을때 변하는 색상
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    // 애니메이터 변수
    Animator anim;
    // 오디오 컴포넌트
    AudioSource playerAudio;
    // 플레이어 움직임 관리 스크립트
    PlayerMovement playerMovement;
    // 죽었는지 확인
    bool isdead;
    // 데미지 입었는지 확인 (player)
    public bool damaged;

    private void Awake()
    {
        // 애니메이터 컴포넌트
        anim = GetComponent<Animator>();
        // 오디오 컴포넌트
        playerAudio = GetComponent<AudioSource>();
        // playermovement 스크립트
        playerMovement = GetComponent<PlayerMovement>();
        // 현재 체력을 최대 체력으로 설정
        currentHealth = startingHealth;
    }

    private void Update()
    {
        if(damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;

    }

    public void TakeDamage(int amount)
    {
        // 공격을 받으면 true
        damaged = true;
        playerMovement.attacking = false;
        playerMovement.dashing = false;
        // 공격 받으면 손실
        currentHealth -= amount;
        // 체력 게이지에 변경된 값을 표시
        healthSlider.value = currentHealth;

        // 만약 체력 0이면
        if(currentHealth <= 0 && !isdead)
        {
            // Death 함수 호출
            Death();
        }
    }

    void Death()
    {
        isdead = true;

        // 애니메이션 Die 트리거 발동
        anim.SetTrigger("Die");
        // 움직임 스크립트 비활성화
        playerMovement.enabled = false;
    }

    public void recovery_strength()
    { // 체력 회복
        if(currentHealth <= startingHealth)
        {
            currentHealth += 20;
            healthSlider.value = currentHealth;
        }
    }

}
