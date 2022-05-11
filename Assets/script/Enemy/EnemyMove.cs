using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    Transform player;
    public UnityEngine.AI.NavMeshAgent nav;

    bool isDead;
    // 사거리
    public float range = 10.0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        isDead = GetComponent<EnemyHealth>().isDead;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    private void Update()
    {
        float dist = Vector3.Distance(player.transform.position, transform.position);
        //float dist = Vector3.Distance(player.transform.position);

        if (dist <= range && nav.enabled == true)
        { // 추적
            nav.SetDestination(player.position);
            nav.Resume();
        }
        else if (dist > range && isDead == false)
        { // 사거리를 벗어나면 추적을 멈춤
            //nav.Stop();
        }
        else if (isDead == true)
        {
            nav.enabled = false;
        }
        // 캐릭터 앞에 멈추기
    }
}
