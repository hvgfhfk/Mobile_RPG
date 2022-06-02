using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent nav;
    public Transform player;

    [SerializeField]
    private EnemyCurrent enemyCurrent;

    public enum CurrentState { idle, trace, attack, dead };
    public CurrentState curState = CurrentState.idle;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();

        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
    }

    IEnumerator CheckState()
    {
        while(!enemyCurrent.isDead)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(player.position, transform.position);

            if(dist <= enemyCurrent.attackDist)
            {
                curState = CurrentState.attack;
            }
            else if(dist <= enemyCurrent.traceDist)
            {
                curState = CurrentState.trace;
            }
            else if(enemyCurrent.isDead)
            {
                curState = CurrentState.dead;
            }
           /* else if (PlayerHealth.instance.isdead == true)
            {
                curState = CurrentState.idle;
            }*/
            else
            {
                curState = CurrentState.idle;
            }
        }
    }

    IEnumerator CheckStateForAction()
    {
        while(!enemyCurrent.isDead)
        {
            switch(curState)
            {
                case CurrentState.idle:
                    nav.Stop();
                    enemyCurrent.m_anim.SetBool("isAttack", false);
                    enemyCurrent.m_anim.SetBool("isTrace", false);
                    break;

                case CurrentState.trace:
                    nav.destination = player.position;
                    nav.Resume();
                    enemyCurrent.m_anim.SetBool("isAttack", false);
                    enemyCurrent.m_anim.SetBool("isTrace", true);
                    break;
                case CurrentState.attack:
                    nav.Stop();
                    enemyCurrent.m_anim.SetBool("isTrace", false);
                    enemyCurrent.m_anim.SetBool("isAttack", true);
                    break;
                case CurrentState.dead:

                    break;
            }
            yield return null;
        }
    }
}
