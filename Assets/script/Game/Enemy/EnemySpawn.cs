using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private UI uiCurrent;

    public static EnemySpawn instance;

    public Transform[] spawnPools; // 적 생성 위치
    public GameObject[] enemyPrefabs; // 적 프리팹

    [SerializeField]
    private float IntervalTime = 10.0f; // 적 생성 시간

    private void Awake()
    {
        // 최대 몬스터를 죽여야 하는 횟수
        uiCurrent.MonsterMaxDead = Random.Range(5, 15);
        EnemySpawn.instance = this;
        InvokeRepeating("Spawn", IntervalTime, IntervalTime);
        // StartCoroutine(StopMonsterSpawn());
    }

    void Spawn()
    {
        int spawnPoolInBox = Random.Range(0, spawnPools.Length);
        int MonsterSpawnNumber = Random.Range(0, enemyPrefabs.Length); // 몬스터의 프리팹을 가져옴
        Instantiate(enemyPrefabs[MonsterSpawnNumber], spawnPools[spawnPoolInBox].position, spawnPools[spawnPoolInBox].rotation);
        uiCurrent.MonsterSpawnCount++;

        if (uiCurrent.MonsterSpawnCount == uiCurrent.MonsterMaxDead)
        {
            CancelInvoke("Spawn");
        }
    }


    /*public void StopSpawn()
    {
        CancelInvoke("Spawn");
    }*/

    public void MonsterCountofKills()
    {
       StartCoroutine(nextSence());
    }

    IEnumerator nextSence()
    { // 한 필드의 몬스터를 다 죽였을 경우 로비 씬으로 넘어감

        yield return new WaitForSeconds(10.0f);
        LoadSceneController.LoadScene("Lobby");
    }

   /* IEnumerator StopMonsterSpawn()
    {
        yield return new WaitForSeconds(1.0f);

        if (uiCurrent.MonsterSpawnCount == uiCurrent.MonsterMaxDead)
        {
            CancelInvoke("Spawn");
        }
    }*/
}
