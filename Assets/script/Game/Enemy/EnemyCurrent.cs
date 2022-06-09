using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCurrent : MonoBehaviour
{ // ?? ???? ????????
    [SerializeField]
    private Player player;

    public string EnemyName; // ???
    public int CurrentHealth; // ? ?? HP
    public float traceDist; // ?? ???
    public float attackDist; // ?? ???
    public int AttackDamage; // ?? ???
    public int StartingHealth; // ?? HP
    public bool isDead; // ?? ??

    public Animator m_anim;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
}
