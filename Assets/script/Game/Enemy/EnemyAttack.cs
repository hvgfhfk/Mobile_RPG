using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private EnemyCurrent enemyCurrent;

    PlayerHealth playerHealth;
    EnemyMove enemymove;
    GameObject player; // 공격 대상

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
            Attack();
        }
    }
    void Attack()
    {
        if(playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(enemyCurrent.AttackDamage);
        }
        else if(playerHealth.currentHealth <= 0)
        {
           InvokeRepeating("PlayerStateCheck", 0.1f, 0.1f);
           StartCoroutine(NextSence());
           
        }
    }

    void PlayerStateCheck()
    {
        enemyCurrent.attackDist = 0;
        enemyCurrent.traceDist = 0;
    }

    IEnumerator NextSence()
    {
        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadSceneAsync("Lobby");
    }
}
