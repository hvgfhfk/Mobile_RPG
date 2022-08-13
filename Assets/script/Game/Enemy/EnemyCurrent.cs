using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCurrent : MonoBehaviour
{
    [SerializeField]
    private Player player;

    public string enemyName; // 적이름
    public int currentHealth; // 적 현재 HP
    public float traceDist; // 추적 사거리
    public float attackDist; // 공격 사거리
    public int attackDamage; // 공격 데미지
    public int startingHealth; // 시작 hp
    public bool isDead; // 죽음 여부
    public int monsterExp;

    public Animator anim;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
