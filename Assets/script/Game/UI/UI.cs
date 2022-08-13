using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField]
    Player playerCurrent;

    public int swordUpgradeCount;  // 무기 업그레이드 수
    public int levelUpDamageUpgradeCount; // 레벨업 시 업그레이드
    public int swordDamage = 5; // 검 공격력
    public int normalDamage = 5; // 일반 공격력
    public int dashDamage = 25; // 스킬 공격력
    public int diamond; // 다이아몬스 수
    public int normalCalc = 0; // 일반 공격 데미지 계산
    public int dashCalc = 0; // 스킬 데미지 계산
    public int exp = 0; // 경험치
    public float maxExp = 100.0f; // 최대 경험치
    public int lv = 1; // 레발
    public int killCount = 0; // 죽인 횟수
    public int monsterMaxDead; // 최대 죽여야 하는 횟수
    public int monsterSpawnCount; // 몬스터 스폰 수
    public int upgradeDefensiveCount; // 방어력 업그레이드 횟수
    public int upgradeDefensive; // 증가 방어력

}
