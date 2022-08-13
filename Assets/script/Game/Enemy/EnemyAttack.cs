using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private EnemyCurrent enemyCurrent;

    PlayerHealth playerHealth;
    EnemyMove enemyMove;
    GameObject player; // 공격 대상

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyMove = GetComponent<EnemyMove>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player && enemyMove.curState == EnemyMove.CurrentState.attack)
        {
            Attack();
        }
    }
    void Attack()
    {
        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(enemyCurrent.attackDamage);
        }
        else if(playerHealth.currentHealth <= 0)
        {
           StartCoroutine(NextSence());
        }
    }

    IEnumerator NextSence()
    {
        yield return new WaitForSeconds(10.0f);
        LoadSceneController.LoadScene("Lobby");
    }
}
