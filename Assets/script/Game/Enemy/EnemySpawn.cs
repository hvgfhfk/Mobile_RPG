using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        EnemySpawn.instance = this;
        InvokeRepeating("Spawn", IntervalTime, IntervalTime);
    }

    void Spawn()
    {
        int spawnPoolInBox = Random.Range(0, spawnPools.Length);
        int MonsterSpawnNumber = Random.Range(0, enemyPrefabs.Length); // �����Լ��� ����� ����
        Instantiate(enemyPrefabs[MonsterSpawnNumber], spawnPools[spawnPoolInBox].position, spawnPools[spawnPoolInBox].rotation);
    }

    public void StopSpawn()
    {
        if(uiCurrent.DeadCount >= uiCurrent.MonsterMaxDead)
        {
            CancelInvoke("Spawn");
            StartCoroutine(nextSence());
        }
    }

    IEnumerator nextSence()
    { // �ش� ���Ͱ� ���������� ���Ͱ� �� �׾��� ��� ���������� �Ѿ��

        yield return new WaitForSeconds(10.0f);
        SceneManager.LoadSceneAsync("Lobby");
    }
}
