using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public enum CurrentState { idle, trace, attack, dead };
    public CurrentState curState = CurrentState.idle;

    Transform player;
    Animator anim;

    public UnityEngine.AI.NavMeshAgent nav;
    EnemyAttack enemyattack;

    bool isDead;

    // 사거리
    public float traceDist = 10.0f;

    // 공격 사거리
    public float attackDist = 1.5f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;


        anim = GetComponent<Animator>();
        isDead = GetComponent<EnemyHealth>().isDead;
        enemyattack = GetComponent<EnemyAttack>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
    }

    IEnumerator CheckState()
    {
        while(!isDead)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(player.position, transform.position);

            if(dist <= attackDist)
            {
                curState = CurrentState.attack;
            }
            else if(dist <= traceDist)
            {
                curState = CurrentState.trace;
            }
            else
            {
                curState = CurrentState.idle;
            }
        }
    }

    IEnumerator CheckStateForAction()
    {
        while(!isDead)
        {
            switch(curState)
            {
                case CurrentState.idle:
                    nav.Stop();
                    anim.SetBool("isAttack", false);
                    anim.SetBool("isTrace", false);
                    break;

                case CurrentState.trace:
                    nav.destination = player.position;
                    nav.Resume();
                    anim.SetBool("isAttack", false);
                    anim.SetBool("isTrace", true);
                    break;
                case CurrentState.attack:
                    nav.Stop();
                    anim.SetBool("isTrace", false);
                    anim.SetBool("isAttack", true);
                    
                    break;
                case CurrentState.dead:
                    nav.enabled = false;
                    break;
            }
            yield return null;
        }
    }
}
