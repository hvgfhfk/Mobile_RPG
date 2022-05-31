using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private int attackDamage = 10;

    GameObject player;
    PlayerHealth playerHealth;
    EnemyMove enemymove;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemymove = GetComponent<EnemyMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && enemymove.curState == EnemyMove.CurrentState.attack)
        {
            //Debug.Log("���� ���� ����");
            Attack();
        }
    }
    void Attack()
    {
        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
