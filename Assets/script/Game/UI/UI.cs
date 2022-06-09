using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public int SwordUpgradeCount;  // 무기 업그레이드 수
    public int LevelUpDamageUpgradeCount; // 레벨업 시 업그레이드
    public int SwordDamage = 5; // 검 공격력
    public int NormalDamage = 5; // 일반 공격력
    public int DashDamage = 25; // 스킬 공격력
    public int Diamond; // 다이아몬스 수
    public int NormalCalc = 0; // 일반 공격 데미지 계산
    public int DashCalc = 0; // 스킬 데미지 계산
    public int Exp = 0; // 경험치
    public float MaxExp = 100.0f; // 최대 경험치
    public int Lv = 1; // 레발
    public int DeadCount = 0; // 죽인 횟수
    public int MonsterMaxDead; // 최대 죽여야 하는 횟수
}
