using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    EnemyCurrent enemyCurrent;

    [SerializeField]
    private UI uiCurrent;

    public static EnemySpawn instance;

    public Transform[] spawnPools; // 적 생성 위치
    public GameObject[] enemyPrefabs; // 적 프리팹

    [SerializeField]
    private float intervalTime = 10.0f; // 적 생성 시간

    private void Awake()
    {
        // 최대 몬스터를 죽여야 하는 횟수
        uiCurrent.monsterMaxDead = Random.Range(5, 10);
        EnemySpawn.instance = this;
        InvokeRepeating("Spawn", intervalTime, intervalTime);
    }

    void Spawn()
    {
        SpawnClass();
        //GameObject target_Object = EnemySpwanPooling.instance.GetQueue();
        //target_Object.transform.position = spawnPools[spawnPoolInBox].position;
        
        if (uiCurrent.monsterSpawnCount == uiCurrent.monsterMaxDead)
        {
            CancelInvoke("Spawn");
        }
    }

    private void SpawnClass()
    {
        int spawnPoolInBox = Random.Range(0, spawnPools.Length);
        int monsterSpawnNumber = Random.Range(0, enemyPrefabs.Length); // 몬스터의 프리팹을 가져옴
        Instantiate(enemyPrefabs[monsterSpawnNumber], spawnPools[spawnPoolInBox].position, spawnPools[spawnPoolInBox].rotation);
        uiCurrent.monsterSpawnCount++;
    }


    public void SenceMoveNext()
    {
       StartCoroutine(NextSence());
    }

    IEnumerator NextSence()
    {
        yield return new WaitForSeconds(10.0f);
        LoadSceneController.LoadScene("Lobby");
    }
}
