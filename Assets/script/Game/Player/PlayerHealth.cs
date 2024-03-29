using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private Player playerCurrent;

    public int currentHealth = 0; // 현재 체력

    // 체력 게이지 UI와 연결된 변수
    public Slider healthSlider;

    // 화면이 변한뒤 투명한 상태로 돌아가는 속도
    private float flashSpeed;
    // 데미지를 입었을때 변하는 색상
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    // 플레이어 움직임 관리 스크립트
    PlayerMovement playerMovement;
    PlayerAttack playerAttack;


    private void Awake()
    {
        // playermovement 스크립트
        playerMovement = GetComponent<PlayerMovement>();
        playerAttack = GetComponent<PlayerAttack>();
    }

    private void Start()
    {
        if (playerCurrent.startingHealth < 100)
        {
            playerCurrent.startingHealth = 100;
        }
        PlayerHpBar();
    }

    public void TakeDamage(int amount)
    {
        // 공격 받으면 손실
        currentHealth -= amount;
        // 체력 게이지에 변경된 값을 표시
        healthSlider.value = currentHealth; // *

        // 만약 체력 0이면
        if(currentHealth <= 0 && !playerCurrent.isDead)
        {
            // Death 함수 호출
            Death();
        }
    }

    void Death()
    {
        OnDie();
        StopSpawn();
        StopSkillAcitve();
        ScriptEnableOff();
    }

    private void PlayerHpBar()
    { // 플레이어 hp바
        healthSlider.maxValue = playerCurrent.startingHealth;
        healthSlider.value = playerCurrent.startingHealth;
        currentHealth = playerCurrent.startingHealth;
    }

    public void RecoveryStrength()
    { // 체력 회복
        if(currentHealth <= healthSlider.maxValue)
        {
            currentHealth += 20;
            healthSlider.value = currentHealth; // *
        }
    }

    private void OnDie()
    { // 플레이어 죽음 확인/애니메이션
        playerCurrent.isDead = true;
        playerCurrent.anim.SetTrigger("Die");
    }
    private void StopSpawn()
    { // 스폰 멈추기
        EnemySpawn.instance.CancelInvoke("Spawn");
    }
    private void StopSkillAcitve()
    { // 스킬 멈추기
        GameObject.Find("SkillDash").SetActive(false);
        GameObject.Find("ButtonAttack").SetActive(false);
    }
    private void ScriptEnableOff()
    { // 움직임 스크립트 , 공격 스크립트 비활성화
        playerMovement.enabled = false;
        playerAttack.enabled = false;
    }
}
